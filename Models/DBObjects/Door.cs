//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelliTransCentre.Models.DBObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class Door
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> CarParkId { get; set; }
        public Nullable<System.Guid> DoorTypeID { get; set; }
        public string DoorName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<bool> HasBluetooth { get; set; }
        public Nullable<bool> HasWifi { get; set; }
        public Nullable<bool> HasNFC { get; set; }
        public string BluetoothMAC { get; set; }
        public string BluetoothCompanyId { get; set; }
        public string BluetoothUuid { get; set; }
        public string WiFiSsid { get; set; }
        public string WiFiMac { get; set; }
        public string WiFiPassword { get; set; }
        public string NFCMAC { get; set; }
        public string Description { get; set; }
        public string IotId { get; set; }
    }
}
