using SharpDX.DirectInput;

namespace MSteerHelp
{
    public class MouseSteering : IDisposable
    {
        public static int MouseSensitivity { get; set; }
        public static int GyroSensitivity { get; set; }
        public static int FFBSensitivity { get; set; }

        private readonly DirectInput directInput;
        private readonly Mouse mouseDevice;
        private int currentAngle; // Текущее положение руля
        public MouseSteering()
        {
            directInput = new DirectInput();
            mouseDevice = new Mouse(directInput);
            mouseDevice.Acquire();
        }



        public int GetSteeringAngle()// Логика управления 
        {
            float Gyro = Program.AngularVelocityY;
            float FFB = Program.FFB;
            var mouseState = mouseDevice.GetCurrentState();
            float steerForce = mouseState.X * MouseSensitivity;

            steerForce += Gyro * GyroSensitivity;
            steerForce -= FFB * FFBSensitivity;

            // Применяем силу к текущему положению руля
            currentAngle += (int)steerForce;

            // Ограничиваем угол руления
            currentAngle = Math.Max(0, Math.Min(32767, currentAngle));

            return currentAngle;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}