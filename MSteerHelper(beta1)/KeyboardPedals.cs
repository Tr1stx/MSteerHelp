using SharpDX.DirectInput;

namespace MSteerHelp
{

    public class KeyboardPedals : IDisposable
    {
        private DirectInput directInput = new DirectInput();
        private Keyboard keyboardDevice;
        private int currentGas;
        private int currentBrake;
        private int currentClutch;

        private const int gasMoveSpeed = 9;
        private const int gasReturnSpeed = 5;

        private const int brakeMoveSpeed = 9;
        private const int brakeReturnSpeed = 5;

        private const int clutchMoveSpeed = 9;
        private const int clutchReturnSpeed = 5;

        public KeyboardPedals()
        {
            directInput = new DirectInput();
            keyboardDevice = new Keyboard(directInput);
            keyboardDevice.Acquire();
        }


        private int GetPedalPressure(Key key, ref int currentValue, int moveSpeed, int returnSpeed)
        {
            var keyboardState = keyboardDevice.GetCurrentState();
            int targetValue = keyboardState.IsPressed(key) ? 100 : 0;

            int speed = keyboardState.IsPressed(key) ? moveSpeed : returnSpeed;

            if (currentValue < targetValue)
                currentValue += Math.Min(speed, targetValue - currentValue);
            else if (currentValue > targetValue)
                currentValue -= Math.Min(speed, currentValue - targetValue);

            return currentValue;
        }

        public int GetGasPressure()// Газ
        {
            int gasPressure = GetPedalPressure(Key.W, ref currentGas, gasMoveSpeed, gasReturnSpeed);

            return gasPressure;
        }


        public int GetBrakePressure() // Тормоз
        {
            int brakePressure = GetPedalPressure(Key.S, ref currentBrake, brakeMoveSpeed, brakeReturnSpeed);

            return brakePressure;
        }

        public int GetClutchPressure() // Сцепление 
        {
            return GetPedalPressure(Key.C, ref currentClutch, clutchMoveSpeed, clutchReturnSpeed);
        }

        public int GetHandBrakePressure() // Ручной тормоз
        {
            var keyboardState = keyboardDevice.GetCurrentState();

            if (keyboardState.IsPressed(Key.Space))
            {
                return 100; // 100% давление
            }
            return 0;
        }

        public int IsButtonPressed1() // Кнопка 1
        {
            var keyboardState = keyboardDevice.GetCurrentState();

            if (keyboardState.IsPressed(Key.E))
            {
                return 100; // 100 давление
            }
            return 0;
        }

        public int IsButtonPressed2() // Кнопка 2
        {
            var keyboardState = keyboardDevice.GetCurrentState();

            if (keyboardState.IsPressed(Key.Q))
            {
                return 100; // 100 давление
            }
            return 0;
        }

        public bool IsTabPressed()
        {
            var keyboardState = keyboardDevice.GetCurrentState();
            return keyboardState.IsPressed(Key.Tab);//Кнопка активации руля 
        }
        void IDisposable.Dispose()
        {
            // Высвобождение ресурсов
            if (keyboardDevice != null)
            {
                keyboardDevice.Dispose();
                keyboardDevice = null;
            }

            if (directInput != null)
            {
                directInput.Dispose();
                directInput = null;
            }
        }
    }

    public struct PedalScaling
    {
        private int maxValue;

        public int MaxValue { get => maxValue; set => maxValue = value; }
    }
}