using MSteer;
using MSteerHelp;

namespace MSteer
{
    public class ABSController
    {
        public static ABSController Instance { get; } = new ABSController();

        private ABSController() { }

        private const float WheelSlipThreshold = 10f;
        private const float PressureReductionFactor = 670;
        private const float PressureIncreaseFactor = 21629f;

        public bool IsABSActive { get; private set; } = false;

        public void ActivateABS()
        {
            IsABSActive = true;
        }

        public void DeactivateABS()
        {
            IsABSActive = false;
        }

        public int ApplyABS(int originalBrakePressure, float currentWheelSlip)
        {
            if (!IsABSActive)
            {
                return originalBrakePressure;
            }

            int newBrakePressure = originalBrakePressure;

            if (currentWheelSlip > WheelSlipThreshold)
            {
                // Уменьшаем давление на тормоза
                newBrakePressure = (int)(originalBrakePressure * PressureReductionFactor);
            }
            else
            {
                // Восстанавливаем давление на тормоза
                newBrakePressure = (int)(originalBrakePressure * PressureIncreaseFactor);

                // Не превышаем исходное давление
                if (newBrakePressure > originalBrakePressure)
                {
                    newBrakePressure = originalBrakePressure;
                }
            }

            return newBrakePressure;
        }
    }

}
