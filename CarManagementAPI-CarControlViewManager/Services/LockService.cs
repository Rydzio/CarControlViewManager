using DatabaseConnection;
using DatabaseConnection.DTO;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class LockService
    {
        private CarManagementContext _context;
        private CarService _carService;

        public LockService(CarManagementContext context, CarService carService)
        {
            _context = context;
            _carService = carService;
        }

        public LockStateDTO GetLockState(int id)
        {
            Car car = _carService.GetCar(id);

            return new LockStateDTO
            {
                AreDoorsBlocked = car.AreDoorsBlocked,
                IsFuelFillerOpen = car.IsFuelFillerOpen,
                IsHoodOpen = car.IsHoodOpen,
                IsRoofOpen = car.IsRoofOpen,
                IsTrunkOpen = car.IsTrunkOpen
            };
        }

        public void PutLockState(int id, LockStateDTO lockState)
        {
            Car car = _carService.GetCar(id);

            car.AreDoorsBlocked = lockState.AreDoorsBlocked;
            car.IsFuelFillerOpen = lockState.IsFuelFillerOpen;
            car.IsHoodOpen = lockState.IsHoodOpen;
            car.IsRoofOpen = lockState.IsRoofOpen;
            car.IsTrunkOpen = lockState.IsTrunkOpen;

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
