using System;
using System.Threading.Tasks;
using DatabaseConnection;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using DatabaseConnection.DTO;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CarStateAlertService
    {
        private CarManagementContext _context;
        private CarService _carService;

        public CarStateAlertService(CarManagementContext context, CarService carService)
        {
            _context = context;
            _carService = carService;
        }
        public async Task<CarStateAlertDTO> GetEmergencyState(int carId)
        {
            Car car = await _context.Cars.FindAsync(carId);

            if (car == null)
            {
                return null;
            }

            return new CarStateAlertDTO()
            {
                CarId = car.CarId,
                brakeFluidLevel = car.ActualBrakeFluidLevel,
                batteryLevel = car.ActualBatteryLevel,
                coolantLevel = car.ActualCoolantLevel,
                lftyrePressure = car.ActualFrontLeftTyrePressure,
                rftyrePressure = car.ActualFrontRightTyrePressure,
                lbtyrePressure = car.ActualRearLeftTyrePressure,
                rbtyrePressure = car.ActualRearLeftTyrePressure,
                motorOil = car.ActualMotorOilLevel,
                windscreenFluid = car.ActualWindscreenWasherLevel,
                serviceDate = car.PreviousServiceDate,
            };
        }

        public async Task<bool> UpdateCarAlertState(int carId, bool newCarAlertState)
        {
            Car car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return false;
            }

            car.IsEmergencyOn = newCarAlertState;
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string> GetAlertNotification(int carId)
        {
            var batteryLevel = _carService.GetBatteryLevel(carId);
            var brakeFluidLevel = _carService.GetBrakeFluidLevel(carId);
            var coolantLevel = _carService.GetCoolantLevel(carId);
            var motorOil = _carService.GetMotorOilLevel(carId);
            var windscreenFluid = _carService.GetWindscreenWasherLevel(carId);
            var serviceDate = _carService.GetPreviousServiceDate(carId);
            var minbatteryLevel = _carService.GetMinBatteryLevel(carId);
            var minbrakeFluidLevel = _carService.GetMinBrakeFluidLevel(carId);
            var mincoolantLevel = _carService.GetMinCoolantLevel(carId);
            var minmotorOil = _carService.GetMinMotorOilLevel(carId);
            var minwindscreenFluid = _carService.GetMinWindscreenWasherLevel(carId);

            if(batteryLevel < minbatteryLevel)
            {
                return "ALERT! Low battery level!";
            }
            if(brakeFluidLevel < minbrakeFluidLevel)
            {
                return "ALERT! Low brake fluid level!";
            }
            if (coolantLevel < mincoolantLevel)
            {
                return "ALERT! Low coolant level!";
            }
            if (motorOil < minmotorOil)
            {
                return "ALERT! Low motor oil level!";
            }
            if (windscreenFluid < minwindscreenFluid)
            {
                return "ALERT! Low windscreen fluid level!";
            }

            return null;
        }


        public async Task<bool> SendNotification(int carId)
        {
            Notification alert = await _context.Notifications.FindAsync(carId);
            return false;
        }
    }
}
