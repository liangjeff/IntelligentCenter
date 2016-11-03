var Spartan;
(function (Spartan) {
    "use strict";
    var IoTController = (function () {
        function IoTController(scope, window, http, q) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.gridDatasource = new kendo.data.DataSource();
            this.gridDatasource.pageSize(20);
            this.q.all({
                getCarList: this.http.get("/Management/IoT/GetCarList")
            }).then(function (d) {
                var list = d["getCarList"].data;
                _this.gridDatasource.data(list);
            }).finally(function () {
            });
        }
        IoTController.prototype.mainGridOptions = function () {
            return {
                dataSource: this.gridDatasource,
                columns: [
                    { title: "UserId", field: "UserId" }, { title: "CarNumber", field: "CarNumber" }, { title: "CarType", field: "CarType" }, { title: "CarName", field: "CarName" },
                    { title: "Description", field: "Description" },
                    { title: "Last Name", field: "HasBluetooth" }, { title: "Last Name", field: "HasWiFi" }, { title: "Last Name", field: "Revision" },
                    { title: "", template: "<a href=''><span class='glyphicon glyphicon-pencil'></span>Edit</a>" },
                    { title: "", template: "<a href=''><span class='glyphicon glyphicon-trash'></span>Delete</a>" }
                ],
                sortable: {
                    mode: "multiple",
                    allowUnsort: true
                },
                autoBind: true,
                pageable: true
            };
        };
        IoTController.$inject = ['$scope', '$window', '$http', '$q'];
        return IoTController;
    }());
    Spartan.IoTController = IoTController;
    var app = angular.module("Spartan");
    app.controller("iotcontroller", IoTController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=IoTCtrl.js.map