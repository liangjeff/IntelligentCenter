var Spartan;
(function (Spartan) {
    "use strict";
    var OverviewController = (function () {
        function OverviewController(//构造函数
            scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.carsDropDown = new kendo.data.DataSource();
            this.viewCarDetails = function (id) {
                console.log(id);
            };
            this.CurrentUserId = currentUserId; //
            this.q.all({
                getUserCars: this.http.get("/Customer/Welcome/GetMyCars?userId=" + currentUserId) //先从数据库获得数据 
            }).then(function (d) {
                _this.myCarsDatasource = (d["getUserCars"].data);
            }).finally(function () {
            });
        }
        OverviewController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return OverviewController;
    }());
    Spartan.OverviewController = OverviewController;
    var app = angular.module("Spartan");
    app.controller("overviewController", OverviewController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=OverviewController.js.map