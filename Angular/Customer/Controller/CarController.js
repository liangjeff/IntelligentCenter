var Spartan;
(function (Spartan) {
    "use strict";
    var CarController = (function () {
        function CarController(//构造函数
            scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.carsDropDown = new kendo.data.DataSource();
            this.myCarsDatasource = new kendo.data.DataSource();
            this.onCarSelectionChange = function () {
                console.log(_this.selectedCarId);
                if (_this.selectedCarId != "0") {
                    _this.q.all({
                        getParkingInfo: _this.http.get("/Customer/Parking/GetParkingInfo?carId=" + _this.selectedCarId)
                    }).then(function (d) {
                        _this.carParkingInfo = d["getParkingInfo"].data;
                    }).finally(function () {
                        console.log(_this.carParkingInfo);
                    });
                }
            };
            this.CurrentUserId = currentUserId; //
            this.q.all({
                getCarDropDownList: this.http.get("/Customer/Parking/GetCarDropDownList?userId=" + currentUserId)
            }).then(function (d) {
                _this.carsDropDown = d["getCarDropDownList"].data;
            }).finally(function () {
            });
            this.q.all({
                getUserCars: this.http.get("/Customer/Parking/GetparkingInfo?carId=" + this.selectedCarId) //先从数据库获得数据 
            }).then(function (d) {
                _this.myCarsDatasource.data(d["getUserCars"].data);
            }).finally(function () {
            });
        }
        CarController.prototype.myCarsGridOptions = function () {
            return {
                dataSource: this.myCarsDatasource,
                columns: [
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
        };
        CarController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return CarController;
    }());
    Spartan.CarController = CarController;
    var app = angular.module("Spartan");
    app.controller("carcontroller", CarController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=CarController.js.map