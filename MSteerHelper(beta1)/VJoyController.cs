using vJoy.Wrapper;

namespace MSteerHelp
{
    public class VJoyController : IDisposable
    {
        public void SetButton(int buttonID, bool isPressed)
        {
            joystick.SetJoystickButton(isPressed, (uint)buttonID);
        }

        private VirtualJoystick joystick;
        private PedalScaling gasScaling;
        private PedalScaling brakeScaling;
        private PedalScaling clutchScaling;
        private PedalScaling handBreakeScaling;

        public VJoyController(uint deviceID)
        {
            joystick = new VirtualJoystick(deviceID);
            joystick.Aquire();

            gasScaling = new PedalScaling { MaxValue = 32767 };  // Оптимальное значение 
            brakeScaling = new PedalScaling { MaxValue = 32767 };
            clutchScaling = new PedalScaling { MaxValue = 32767 };
            handBreakeScaling = new PedalScaling { MaxValue = 32767 };
        }

        public void SetSteering(int value)
        {
            joystick.SetJoystickAxis(value, Axis.HID_USAGE_X);
        }

        public void SetPedalAxis(int pedalID, int value, Exception exception)
        {
            PedalScaling scaling;

            switch (pedalID)
            {
                case 2:
                    scaling = gasScaling;
                    break;
                case 3:
                    scaling = brakeScaling;
                    break;
                case 4:
                    scaling = clutchScaling;
                    break;
                case 5:
                    scaling = handBreakeScaling;
                    break;
                default:
                    throw exception;
            }

            int scaledValue = value * scaling.MaxValue / 100; // Масштабирование значения

            Axis axis;
            switch (pedalID)
            {
                case 2:
                    axis = Axis.HID_USAGE_Y; // Газ
                    break;
                case 3:
                    axis = Axis.HID_USAGE_Z; // Тормоз
                    break;
                case 4:
                    axis = Axis.HID_USAGE_RX; // Сцепление
                    break;
                case 5:
                    axis = Axis.HID_USAGE_RY; // Ручной тормоз
                    break;
                default:
                    throw new Exception($"Invalid pedalID: {pedalID}");
            }
            joystick.SetJoystickAxis(scaledValue, axis);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}