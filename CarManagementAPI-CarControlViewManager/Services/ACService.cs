using DatabaseConnection;
using DatabaseConnection.DTO;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ACService
    {
        private CarManagementContext _context;
        private CarService _carService;


        public ACService(CarManagementContext context, CarService carService)
        {
            _context = context;
            _carService = carService;
        }

        public ACStateDTO GetACState(int id)
        {
            Car car = _carService.GetCar(id);

            return new ACStateDTO
            {
                ACTemp = car.ClimaTemperature,
                InsideTemp = car.InsideTemperature,
                OutsideTemp = car.OutsideTemperature,
                HotChairLevel = car.HotChairLevel,
                IsACOn = car.IsClimaOn
            };
        }

        public void PutACState(int id, ACStateDTO acState)
        {
            Car car = _carService.GetCar(id);

            car.ClimaTemperature = acState.ACTemp;
            car.InsideTemperature = acState.InsideTemp;
            car.OutsideTemperature = acState.OutsideTemp;
            car.HotChairLevel = acState.HotChairLevel;
            car.IsClimaOn = acState.IsACOn;

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool ChangeACTemp(int id, float newTemp)
        {
            Car car = _carService.GetCar(id);
            if(car == null)
            {
                return false;
            }

            car.ClimaTemperature = newTemp;
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool ToggleAC(int id)
        {
            Car car = _carService.GetCar(id);
            if(car == null)
            {
                return false;
            }
            car.IsClimaOn = !car.IsClimaOn;
            _context.Entry(car).State = EntityState.Modified;
            return true;
        }

        public bool ChangeHotChairLevel(int id, HotChairLevel newLevel)
        {
            Car car = _carService.GetCar(id);
            
            if(car == null)
            {
                return false;
            }

            car.HotChairLevel = newLevel;
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
