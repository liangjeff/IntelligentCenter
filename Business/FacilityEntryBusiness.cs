using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Models.DBObjects;
using IntelliTransCentre.Models.ViewModels;
using Microsoft.ApplicationInsights.Web;

namespace IntelliTransCentre.Business
{
    public class FacilityEntryBusiness : IFacilityEntryBusiness
    {
        

        public IList<FacilityEntryRecordViewModels> GetEntryRecord()
        {
            using (var context = new SpartanEntities())
            {
                var entryrecordlist = new List<FacilityEntryRecordViewModels>();
                var doorids = context.EntryRecords.Select(rec => rec.DoorId);
                var doornames = context.Doors.Where(rec => doorids.Contains(rec.Id)).ToList();
                var carids = context.EntryRecords.Select(rec => rec.CarId);
                var carnumbers = context.Cars.Where(rec => carids.Contains(rec.Id)).ToList();
                foreach (var entrylist in context.EntryRecords)
                {
                    var  doorname = doornames.FirstOrDefault(rec => rec.Id == entrylist.DoorId);
                    var carnumber = carnumbers.FirstOrDefault(rec=> rec.Id == entrylist.CarId);
                    var recordItem = new FacilityEntryRecordViewModels()
                    {
                        DoorName = doorname.DoorName, 
                        TimeStamp = entrylist.TimeStamp.ToString(),
                        CarNumber = carnumber.CarNumber,
                        EntryStatus = "Parking"  
                    };
                    entryrecordlist.Add(recordItem);
                }
                return entryrecordlist;
            }
        }
    }
}