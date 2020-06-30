using Recodme.RD.Lennyouse.BusinessLayer.Base;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Recodme.RD.Lennyouse.BusinessLayer.ExtendedMethods;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfoDAO;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects
{
    public class ExtraBusinessObject: BaseBusinessObject
    {
        private RestaurantDataAccessObject _rdao = new RestaurantDataAccessObject();
        private BookingDataAccessObject _bdao = new BookingDataAccessObject();
        private ClientRecordDataAccessObject _cdao = new ClientRecordDataAccessObject();
        private DishDataAccessObject _ddao = new DishDataAccessObject();
        private DietaryRestrictionDataAccessObject _drdao = new DietaryRestrictionDataAccessObject();

        public OperationResult<Dictionary<Restaurant, int>> GetAvailableTables()
        {
            return ExecuteTransaction(
            () =>
            {
                var restaurants = _rdao.List().Where(x => !x.IsDeleted);
                var bookings = _bdao.List().Where(b => b.Date.IsToday());
                var clients = _cdao.List().Where(c => bookings.Any(b => b.ClientRecordId == c.Id));

                var dict = new Dictionary<Restaurant, int>();
                foreach (var rest in restaurants)
                {
                    var bookingsInRetaurant = clients.Count(c => restaurants.Any(x => x.Id == c.RestaurantId));
                    var emptyTables = rest.TableCount - bookingsInRetaurant;
                    dict.Add(rest, emptyTables);
                }
                return dict;
            });
            
        }
        public OperationResult<int> GetAvailableTables(Guid restaurantId)
        {
            return ExecuteTransaction(
            () =>
            {
                var restaurant = _rdao.Read(restaurantId);
                if (restaurant == null) return 0;
                var bookings = _bdao.List().Where(b => b.Date.IsToday());
                var clients = _cdao.List().Where(c => bookings.Any(b => b.ClientRecordId == c.Id));
                var bookingsInRestaurant = clients.Count(c => c.RestaurantId == restaurant.Id);
                return restaurant.TableCount - bookingsInRestaurant;
            });
        }

        public OperationResult<int> GetDishCountBasedOnDietaryRestriction(Guid dietaryRestrictionId)
        {
            return ExecuteTransaction(
                () =>
                {
                    var dietaryRestriction = _drdao.Read(dietaryRestrictionId);
                    if (dietaryRestriction == null) return 0;
                    var dishes = _ddao.List().Where(d => d.DietaryRestrictionId == dietaryRestriction.Id);
                    return dishes.Count();
                });
        }
    }
}
