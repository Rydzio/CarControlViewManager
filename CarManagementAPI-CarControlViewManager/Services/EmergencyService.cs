using System;
using System.Threading.Tasks;
using DatabaseConnection;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTO;

namespace Services
{
    public class EmergencyService
    {
        private readonly CarManagementContext _context;
        private readonly LocalizationService _localizationService;

        public EmergencyService(CarManagementContext context, LocalizationService localizationService )
        {
            _context = context;
            _localizationService = localizationService;
        }

        public async Task<EmergencyStateDTO> GetEmergencyState(int carId)
        {
            Car car = await _context.Cars.FindAsync(carId);

            if (car == null)
            {
                return null;
            }

            return new EmergencyStateDTO()
            {
                CarId = car.CarId,
                IsBlocked = car.IsBlocked,
                AreDoorsBlocked = car.AreDoorsBlocked,
                BlockedLocationY = car.BlockedLocationY,
                BlockedLocationX = car.BlockedLocationX,
            };
        }

        public async Task<bool> UpdateEmergencyState(int carId, bool newEmergencyState)
        {
            Car car = await _context.Cars.FindAsync( carId );
            if (car == null)
            {
                return false;
            }

            car.IsEmergencyOn = newEmergencyState;
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAlarmState( int carId, bool newAlarmState)
        {
            Car car = await _context.Cars.FindAsync( carId );
            if ( car == null )
            {
                return false;
            }

            car.IsEmergencyOn = newAlarmState;
            _context.Entry( car ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Tuple<float, float>> GetBlockedLocation(int carId)
        {
            Car car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return null;
            }

            return new Tuple<float, float>(car.BlockedLocationX, car.BlockedLocationY);
        }

        public async Task<string> GetEmergencyNotification(int carId)
        {
            var actualLocation = await _localizationService.GetLocalization( carId );
            var blockedLocation = await GetBlockedLocation( carId );
            var distance = this.Distance(actualLocation.Item1, actualLocation.Item2, blockedLocation.Item1,
                blockedLocation.Item2, 'K');
            if (distance > 0.5)
            {
                return "ALARM! Someone may be stealing your car!";
            }

            return null;
        }

        private void SendNotification()
        {
            //TODO notify central
        }

        public double Distance( double lat1, double lon1, double lat2, double lon2, char unit )
        {
            if ( ( lat1 == lat2 ) && ( lon1 == lon2 ) )
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin( deg2rad( lat1 ) ) * Math.Sin( deg2rad( lat2 ) ) + Math.Cos( deg2rad( lat1 ) ) * Math.Cos( deg2rad( lat2 ) ) * Math.Cos( deg2rad( theta ) );
                dist = Math.Acos( dist );
                dist = rad2deg( dist );
                dist = dist * 60 * 1.1515;
                if ( unit == 'K' )
                {
                    dist = dist * 1.609344;
                }
                else if ( unit == 'N' )
                {
                    dist = dist * 0.8684;
                }
                return ( dist );
            }
        }

        private double deg2rad( double deg )
        {
            return ( deg * Math.PI / 180.0 );
        }

        private double rad2deg( double rad )
        {
            return ( rad / Math.PI * 180.0 );
        }

    }
}