using MSteerHelp;
using System;
using Windows.Devices.Adc;

namespace MSteer
{

    public class GameControls : IDisposable
    {
        private readonly ABSController absController = ABSController.Instance;
        private readonly MouseSteering mouseSteering;
        private readonly KeyboardPedals keyboardPedals;
        private readonly VJoyController vJoyController;

        public GameControls(uint vJoyDeviceID)
        {
            mouseSteering = new MouseSteering();
            keyboardPedals = new KeyboardPedals();
            vJoyController = new VJoyController(vJoyDeviceID);
        }

        public void UpdateControls()
        {
            int steeringValue = mouseSteering.GetSteeringAngle();
            vJoyController.SetSteering(steeringValue); // Ось 1 для руля

            int brakePressure = keyboardPedals.GetBrakePressure();
            float currentWheelSlip = Program.WhSlip;
            int modifiedBrakePressure = absController.ApplyABS(brakePressure, currentWheelSlip);

            vJoyController.SetPedalAxis(2, keyboardPedals.GetGasPressure(), new Exception($"Invalid pedalID: {2}")); // Ось 2 для газа
            vJoyController.SetPedalAxis(3, modifiedBrakePressure, new Exception($"Invalid pedalID: {3}")); // Ось 3 для тормоза
            vJoyController.SetPedalAxis(4, keyboardPedals.GetClutchPressure(), new Exception($"Invalid pedalID: {4}")); // Ось 4 для сцепления
            vJoyController.SetPedalAxis(5, keyboardPedals.GetHandBrakePressure(), new Exception($"Invalid pedalID: {5}")); // Ось 5 для ручного тормоза

            vJoyController.SetButton(2, keyboardPedals.IsButtonPressed1() == 100); // Кнопка Q
            vJoyController.SetButton(1, keyboardPedals.IsButtonPressed2() == 100); // Кнопка E
        }

        void IDisposable.Dispose()
        {
            // Здесь можно освободить ресурсы, если это необходимо
            throw new NotImplementedException();
        }
    }
}
