﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelliTransCentre.Models.ViewModels;

namespace IntelliTransCentre.Business.Interface
{
    public interface IFacilityEntryBusiness
    {
        IList<FacilityEntryRecordViewModels> GetEntryRecord();
    }
}