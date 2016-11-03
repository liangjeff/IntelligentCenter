var Spartan;
(function (Spartan) {
    "use strict";
    var Carpark_parkingController = (function () {
        function Carpark_parkingController(//构造函数
            scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.CurrentUserId = currentUserId; //
            this.q.all({
                GetCarpark_parkinginfo: this.http.get("/Facility/Carpark_parkinginfo/GetCarpark_Parkinginfo")
            }).then(function (d) {
                _this.parkinginfodatasource = d["GetCarpark_parkinginfo"].data;
            }).finally(function () {
            });
        }
        Carpark_parkingController.prototype.myCarsGridOptions = function () {
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
        };
        Carpark_parkingController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return Carpark_parkingController;
    }());
    Spartan.Carpark_parkingController = Carpark_parkingController;
    var app = angular.module("Spartan");
    app.controller("carpark_parkingcontroller", Carpark_parkingController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=Carpark_parkingController.js.map