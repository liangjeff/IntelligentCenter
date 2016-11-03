module Spartan {
    "use strict";

    export class CarController {
        public CurrentUserId: string;
        public carsDropDown = new kendo.data.DataSource();
        public myCarsDatasource = new kendo.data.DataSource();
        public selectedCarId: string;
        public carParkingInfo: any;
        public label: any;

        static $inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];//注入元素   包括id

        constructor(//构造函数
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService,
            private currentUserId: string) {

            this.CurrentUserId = currentUserId;//

            this.q.all({
                getCarDropDownList: this.http.get("/Customer/Parking/GetCarDropDownList?userId=" + currentUserId)
            }).then((d) => {
                this.carsDropDown = d["getCarDropDownList"].data;
            }).finally(() => {

                });

            this.q.all({
                getUserCars: this.http.get("/Customer/Parking/GetparkingInfo?carId=" + this.selectedCarId)//先从数据库获得数据 
            }).then((d) => {
                this.myCarsDatasource.data(d["getUserCars"].data);
            }).finally(() => {

            });
        }

        public onCarSelectionChange = () => {
            console.log(this.selectedCarId);
            if (this.selectedCarId != "0"){
                this.q.all({
                    getParkingInfo: this.http.get("/Customer/Parking/GetParkingInfo?carId=" + this.selectedCarId)
                }).then((d) => {
                    this.carParkingInfo = d["getParkingInfo"].data;
                }).finally(() => {
                    console.log(this.carParkingInfo);
                });
            }
        }

        public myCarsGridOptions(): kendo.ui.GridOptions {//kendo 框架
            return {
                dataSource: this.myCarsDatasource,
                columns: [//显示得元素
                    { title: "Car Id", field: "CarId" },
                    { title: "Car Name", field: "CarName" },
                    { title: "Fee", field: "Fare" },
                    { title: "Duration", field: "EnterTime" },
                    
                ],
                sortable: {
                    mode: "multiple",
                    allowUnsort: true
                },
                autoBind: true,
                pageable: true
            };
        }
    }
    var app = angular.module("Spartan");
    app.controller("carcontroller", CarController);
}