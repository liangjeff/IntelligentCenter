module Spartan {
    "use strict";

    export class CarparkinfoController {
        public CurrentUserId: string;
        public RateDatasource : any;
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
                getrateinfo: this.http.get("/Facility/Carparkinfo/GetCarparkRate?userId=" + currentUserId)
            }).then((d) => {
                this.RateDatasource = d["getrateinfo"].data;
            }).finally(() => {
                console.log(this.RateDatasource);
                });
            this.q.all({
                getcarparkinfo: this.http.get("/Facility/Carparkinfo/Getparkinginfo?userId=" + currentUserId)
            }).then((d) => {
                this.carParkingInfo = d["getcarparkinfo"].data;
            }).finally(() => {

            });
        }
        
        
    }
    var app = angular.module("Spartan");
    app.controller("carparkindfocontroller", CarparkinfoController);
}