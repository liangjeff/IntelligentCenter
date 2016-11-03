module Spartan {
    "use strict";

    export class Carpark_parkingController {
        public CurrentUserId: string;
        public parkinginfodatasource: any;
        public selectedCarId: string;
        public carParkingInfo: any;
        public lable1: any;

        static $inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];//注入元素   包括id

        constructor(//构造函数
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService,
            private currentUserId: string) {

            this.CurrentUserId = currentUserId;//

            this.q.all({
                GetCarpark_parkinginfo: this.http.get("/Facility/Carpark_parkinginfo/GetCarpark_Parkinginfo")
            }).then((d) => {
                this.parkinginfodatasource = d["GetCarpark_parkinginfo"].data;
            }).finally(() => {

            });
        }

        
        public myCarsGridOptions(): kendo.ui.GridOptions {//kendo 框架
            return {
                dataSource: this.parkinginfodatasource,
                columns: [
                    { title: "TypeName", field: "TypeName" },
                    { title: "Latitude", field: "Latitude" },
                    { title: "Longtitude", field: "Longtitude" },
                    { title: "LocationCode", field: "LocationCode" },
                    { title: "ParkingTime", field: "ParkingTime" },
                   
                ],
                sortable: {
                    mode: "multiple",
                    allowUnsort: true
                },
                autoBind: true,
                pageable: true
            };
        }

        //public onCarSelectionChange = () => {//无法获得select的id
        //    console.log(this.selectedCarId);

        //    this.q.all({
        //        getParkingInfo: this.http.get("/Customer/Parking/GetParkingInfo?carId=" + this.selectedCarId)
        //    }).then((d) => {
        //        this.carParkingInfo = d["getParkingInfo"].data;
        //    }).finally(() => {
        //        console.log(this.carParkingInfo);
        //    });
        //}
    }
    var app = angular.module("Spartan");
    app.controller("carpark_parkingcontroller", Carpark_parkingController);
}