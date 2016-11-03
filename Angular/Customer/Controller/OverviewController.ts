module Spartan {
    "use strict";

    export class OverviewController {
        public myCarsDatasource : any;
        public CurrentUserId: string;
        public selectedCarId: string;
        public carParkingInfo: any;
        public carsDropDown = new kendo.data.DataSource();

        static $inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];//注入元素   包括id

        constructor(//构造函数
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService,
            private currentUserId: string) {

            this.CurrentUserId = currentUserId;//

            this.q.all({
                getUserCars: this.http.get("/Customer/Welcome/GetMyCars?userId=" + currentUserId)//先从数据库获得数据 
            }).then((d) => {
                this.myCarsDatasource= (d["getUserCars"].data);
            }).finally(() => {

                });
            
        }
        

        public viewCarDetails = (id: string) => {
            console.log(id);
        }
    }
    var app = angular.module("Spartan");
    app.controller("overviewController", OverviewController);
}