using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Common;
using IntelliTransCentre.Models.DBObjects;
using IntelliTransCentre.Models.ViewModels;

namespace IntelliTransCentre.Business
{
    public class UserParkingBusiness : IUserParkingBusiness
    {
        public IList<UserParkingViewModels> GetUserParking(Guid userId)
        {
            using (var context = new SpartanEntities())
            {
                var parkinglist = new List<UserParkingViewModels>();

                var userParking = context.CarOwnerships.Where(rec => rec.UserId == userId);
                var carIds = userParking.Select(rec => rec.CarId);
                var cars = context.Cars.Where(rec => carIds.Contains(rec.Id)).ToList();
                var carparking = context.CarParkingSpaces.Where(rec => carIds.Contains(rec.CarId)).ToList();

                foreach (var usercar in carparking)
                {
                    var car = cars.FirstOrDefault(rec => rec.Id == usercar.CarId);
                    var parking = carparking.FirstOrDefault(rec => rec.CarId == usercar.CarId);

                    var parkingItem = new UserParkingViewModels()
                    {
                        Id = usercar.Id,
                        ParkingSpaceId = parking.ParkingSpaceId.Value,
                        //   ParkingType = parking.ParkingType.ToString(),
                        CarName = car.CarName,
                        CarNumber = car.CarNumber,
                        CarType = car.CarType,
                        
                        //  TimeStamp = parking.TimeStamp.HasValue? parking.TimeStamp.Value.ToString():""
                    };

                    parkinglist.Add(parkingItem);
                }

                return parkinglist;
            }
        }
 
        public IList<ParkingInfoViewModel> GetParkingInfo(Guid carid)
        {

            using (var context = new SpartanEntities())
            {
                var parkingcarinfolist = new List<ParkingInfoViewModel>();


                var carinfo = context.Cars.FirstOrDefault(rec =>rec.Id==carid);
                var carparkinfo = context.CarParkingSpaces.FirstOrDefault(rec => rec.CarId == carid);
                
 


                    var parkingcars = new ParkingInfoViewModel()
                    {
                          CarId = carid,
                          CarName = carinfo.CarName,
                          Fare = "$20",
                          EnterTime = carparkinfo.EnterTime.ToString(),
                          Location = "C11" 

                          
                          

                        
                    };

                    parkingcarinfolist.Add(parkingcars);
                

                return parkingcarinfolist;
            }







            //return new ParkingInfoViewModel()
            //{

            //    CarId = carid,
            //    CarName = "Car Name",
            //    Fare = 10,
            //    ParkingAddress = "Redfern"
            //};


        }

        public IList<DropDownList> GetUserCarsDownList(Guid userId)
        {
            using (var context = new SpartanEntities())
            {
                var cardropdownlist = new List<DropDownList>();

                var userParking = context.CarOwnerships.Where(rec => rec.UserId == userId);
                var carIds = userParking.Select(rec => rec.CarId);
                var cars = context.Cars.Where(rec => carIds.Contains(rec.Id)).ToList();

                foreach (var usercar in cars)
                {
                    var car = cars.FirstOrDefault(rec => rec.Id == usercar.Id);
         

                    var parkingItem = new DropDownList()
                    {
                       Text= car.CarName,
                       Value = usercar.Id.ToString(),
                    };

                    cardropdownlist.Add(parkingItem);
                }

                return cardropdownlist;
            }
            //return new List<DropDownList>()
            //{
            //    new DropDownList()
            //    {
            //        Text = "test",
            //        Value = userId.ToString()
            //    },
            //    new DropDownList()
            //    {
            //        Text = "abc",
            //        Value = userId.ToString()
            //    }
            //};
        }


    }
}