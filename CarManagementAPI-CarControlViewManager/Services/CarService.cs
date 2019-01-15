using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseConnection;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CarService
    {
        public CarManagementContext Context { get; set; }

        public CarService(CarManagementContext context)
        {
            Context = context;
        }

        public Car GetCar(int id)
        {
            return Context.Cars.Find(id);
        }

        public float? GetBrakeFluidLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }

            return GetPercantage(car.ActualBrakeFluidLevel, car.MaxBrakeFluidLevel);
        }
        public float? GetMinBrakeFluidLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }

            return GetPercantage(car.MinBrakeFluidLevel, car.MaxBrakeFluidLevel);
        }


        public float? GetBatteryLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.ActualBatteryLevel, car.MaxBatteryLevel);
        }
        public float? GetMinBatteryLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.MinBatteryLevel, car.MaxBatteryLevel);
        }

        public float? GetCoolantLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.ActualCoolantLevel, car.MaxCoolantLevel);
        }
        public float? GetMinCoolantLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.MinCoolantLevel, car.MaxCoolantLevel);
        }

        public Dictionary<string, float> GetTyresLevels(int carId)
        {
            string front = "Front";
            string rear = "Rear";
            string right = "Right";
            string left = "left";

            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            var tyresPressureLevels = new Dictionary<string, float>
            {
                { front + right, GetPercantage(car.ActualFrontRightTyrePressure, car.MaxTyrePressure) },
                { front + left, GetPercantage(car.ActualFrontLeftTyrePressure, car.MaxTyrePressure) },
                { rear + right, GetPercantage(car.ActualRearRightTyrePressure, car.MaxTyrePressure) },
                { rear + left, GetPercantage(car.ActualRearLeftTyrePressure, car.MaxTyrePressure) },
            };
            return tyresPressureLevels;
        }

        public float? GetMotorOilLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.ActualMotorOilLevel, car.MaxMotorOilLevel);
        }

        public float? GetMinMotorOilLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.MinMotorOilLevel, car.MaxMotorOilLevel);
        }

        public float? GetWindscreenWasherLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.ActualWindscreenWasherLevel, car.MaxWindscreenWasherLevel);
        }
        public float? GetMinWindscreenWasherLevel(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return GetPercantage(car.MinWindscreenWasherLevel, car.MaxWindscreenWasherLevel);
        }

        public DateTime? GetPreviousServiceDate(int carId)
        {
            Car car = GetCar(carId);
            if (car == null)
            {
                return null;
            }
            return car.PreviousServiceDate;
        }

        private float GetPercantage(float actualValue, float maxValue)
        {
            return (actualValue / maxValue) * 100f;
        }
    }
}
