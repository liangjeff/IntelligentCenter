module Spartan {
    "use strict";

    export class EntryRecordController {
        public CurrentUserId: string;
        public EntryRecordDataSource :any;
        public selectedCarId: string;
        public carParkingInfo: any;

        static $inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];//注入元素   包括id

        constructor(//构造函数
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService,
            private currentUserId: string) {

            this.CurrentUserId = currentUserId;//

            this.q.all({
                getentryrecord: this.http.get("/Facility/EntryRecord/GetEntryRecord")
            }).then((d) => {
                this.EntryRecordDataSource = d["getentryrecord"].data;
            }).finally(() => {

            });
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
    app.controller("entryrecordcontroller", EntryRecordController);
}