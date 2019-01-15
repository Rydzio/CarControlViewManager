using System;
using System.Threading.Tasks;
using DatabaseConnection;
using DatabaseConnection.Entities;

namespace Services
{
    public class LocalizationService
    {
        private CarManagementContext _context;

        public LocalizationService( CarManagementContext context )
        {
            _context = context;
        }

        public async Task<Tuple<float, float>> GetLocalization(int carId)
        {
            Car car = await _context.Cars.FindAsync( carId );
            if (car == null)
                return null;
            return Tuple.Create(car.LocationX, car.LocationY);
        }
    }
}