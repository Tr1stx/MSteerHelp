using System;
using System.Runtime.InteropServices;
using AssettoCorsaSharedMemory;
using System.Windows;
using System.Threading;
using MSteer;
using MSteerHelp;


class Program
{
    private static Thread scriptThread;  // Объявите scriptThread как поле класса
    private static bool keepRunning = true;

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int x, int y);
    public static float AngularVelocityY;
    public static float FFB;
    public static float Speed;
    public static float WhSlip;

    //------------------------------------------------------

    [STAThread]
    static void Main(string[] args)
    {
        scriptThread = new Thread(new ThreadStart(RunScript));  // Инициализируйте scriptThread
        scriptThread.Start();

        Application app = new();
        MainWindow mainWindow = new();
        mainWindow.Closing += MainWindow_Closing;
        app.Run(mainWindow);
    }

    private static void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        StopScript();
        if (scriptThread != null && scriptThread.IsAlive)
        {
            scriptThread.Interrupt();  // Прервите поток, если он все еще активен
            scriptThread.Join();  // Дождитесь завершения потока перед закрытием приложения
        }
    }

    public static void StopScript()
    {
        keepRunning = false;
    }

    public static void RunScript()
    {
        uint vJoyDeviceID = 1;
        GameControls gameControls = new(vJoyDeviceID);
        KeyboardPedals keyboardPedals = new();
        bool controlEnabled = true;

        AssettoCorsa ac = new()
        {
            StaticInfoInterval = 100,
            PhysicsInterval = 100,
            GraphicsInterval = 1000
        };
        ac.PhysicsUpdated += AccClientStaticInfoUpdated;

        ac.Start();

        static void AccClientStaticInfoUpdated(object sender, PhysicsEventArgs e)
        {
            AngularVelocityY = e.Physics.LocalAngularVelocity[1];
            FFB = e.Physics.FinalFF;
            Speed = e.Physics.SpeedKmh;
            WhSlip = e.Physics.WheelSlip[0] + e.Physics.WheelSlip[1] / 2;

        }

        try
        {
            while (keepRunning)
            {
                if (keyboardPedals.IsTabPressed())
                {
                    controlEnabled = !controlEnabled;
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine($"Control is now {(controlEnabled ? "ENABLED" : "DISABLED")}");
                }

                if (controlEnabled)
                {
                    gameControls.UpdateControls();
                    SetCursorPos(0, 9999);
                }

                try
                {
                    System.Threading.Thread.Sleep((int)1);
                }
                catch (ThreadInterruptedException)
                {
                    // Поток был прерван, выйдите из цикла
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
