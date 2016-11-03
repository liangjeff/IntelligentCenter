using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Models.DBObjects;
using IntelliTransCentre.Models.ViewModels;

namespace IntelliTransCentre.Business
{
    public class UserCarBusiness: IUserCarBusiness
    {
        public IList<UserCarGridItem> GetUserCar(Guid userId)
        {
            using (var context = new SpartanEntities())
            {
                var carList = new List<UserCarGridItem>();

                var userCars = context.CarOwnerships.Where(rec => rec.UserId == userId);
                var carIds = userCars.Select(rec => rec.CarId);
                var cars = context.Cars.Where(a => carIds.Contains(a.Id)).ToList();

                foreach (var userCar in userCars)
                {
                    var car = cars.FirstOrDefault(rec => rec.Id == userCar.CarId);

                    var carItem = new UserCarGridItem
                    {
                        Id = userCar.Id,
                        CarId = car.Id,
                        CarName = car.CarName,
                        CarNumber = car.CarNumber,
                        CarType = car.CarType,
                        Description = car.Description,
                        RegisteredDate = userCar.RegisteredDate.HasValue ? userCar.RegisteredDate.Value.ToShortDateString() : ""
                    };

                    carList.Add(carItem);
                }

                return carList;
            }
        }
    }
}