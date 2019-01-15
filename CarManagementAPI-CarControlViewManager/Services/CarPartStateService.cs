using DatabaseConnection;
using DatabaseConnection.DTO;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CarPartStateService
    {
        private CarManagementContext _context;
        private CarService _carService;

        public CarPartStateService(CarManagementContext context, CarService carService)
        {
            _context = context;
            _carService = carService;
        }

        public CarPartStateDTO GetLockState(int id)
        {
            Car car = _carService.GetCar(id);

            return new CarPartStateDTO
            {
                ToggleLock = car.AreDoorsBlocked,
                ToggleFuelCap = car.IsFuelFillerOpen,
                ToggleHood = car.IsHoodOpen,
                ToggleRoof = car.IsRoofOpen,
                ToggleTrunk = car.IsTrunkOpen
            };
        }

        public void PutLockState(int id, CarPartStateDTO State)
        {
            Car car = _carService.GetCar(id);

            car.AreDoorsBlocked = State.ToggleLock;
            car.IsFuelFillerOpen = State.ToggleFuelCap;
            car.IsHoodOpen = State.ToggleHood;
            car.IsRoofOpen = State.ToggleRoof;
            car.IsTrunkOpen = State.ToggleTrunk;

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
