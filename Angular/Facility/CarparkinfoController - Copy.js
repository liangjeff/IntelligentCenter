var Spartan;
(function (Spartan) {
    "use strict";
    var CarparkinfoController = (function () {
        function CarparkinfoController(//构造函数
            scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.carsDropDown = new kendo.data.DataSource();
            this.CurrentUserId = currentUserId; //
            this.q.all({
                getcarparkinfo: this.http.get("/Facility/Carparkinfo/Getparkinginfo?userId=" + currentUserId)
            }).then(function (d) {
                _this.carParkingInfo = d["getcarparkinfo"].data;
            }).finally(function () {
            });
        }
        CarparkinfoController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return CarparkinfoController;
    }());
    Spartan.CarparkinfoController = CarparkinfoController;
    var app = angular.module("Spartan");
    app.controller("carparkindfocontroller", CarparkinfoController);
})(Spartan || (Spartan = {}));
