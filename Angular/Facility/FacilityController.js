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
            this.onCarSelectionChange = function () {
                console.log(_this.selectedCarId);
                _this.q.all({
                    getParkingInfo: _this.http.get("/Customer/Parking/GetParkingInfo?carId=" + _this.selectedCarId)
                }).then(function (d) {
                    _this.carParkingInfo = d["getParkingInfo"].data;
                }).finally(function () {
                    console.log(_this.carParkingInfo);
                });
            };
            this.CurrentUserId = currentUserId; //
            this.q.all({
                getCarDropDownList: this.http.get("/Customer/Parking/GetCarDropDownList?userId=" + currentUserId)
            }).then(function (d) {
                _this.carsDropDown = d["getCarDropDownList"].data; //从这里得到UserCars
            }).finally(function () {
            });
        }
        CarController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return CarController;
    }());
    Spartan.CarController = CarController;
    var app = angular.module("Spartan");
    app.controller("carcontroller", CarController);
})(Spartan || (Spartan = {}));
