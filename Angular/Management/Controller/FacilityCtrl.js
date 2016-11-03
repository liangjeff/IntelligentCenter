var Spartan;
(function (Spartan) {
    "use strict";
    var FacilityController = (function () {
        function FacilityController(scope, window, http, q) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.gridDatasource = new kendo.data.DataSource();
            this.gridDatasource.pageSize(20);
            this.q.all({
                getCarparkList: this.http.get("/Management/Facility/GetCarparkList")
            }).then(function (d) {
                var list = d["getCarparkList"].data;
                _this.gridDatasource.data(list);
            }).finally(function () {
            });
        }
        FacilityController.prototype.mainGridOptions = function () {
            return {
                dataSource: this.gridDatasource,
                columns: [
                    { title: "ID", field: "ID" },
                    { title: "Name", field: "Name" },
                    { title: "Description", field: "Description" },
                    { title: "StreetNumber", field: "StreetNumber" },
                    { title: "ContactName", field: "ContactName" },
                    { title: "StreetName", template: "<a href=''><span class='glyphicon glyphicon-pencil'></span>Edit</a>" },
                    { title: "City", template: "<a href=''><span class='glyphicon glyphicon-trash'></span>Delete</a>" }
                ],
                sortable: {
                    mode: "multiple",
                    allowUnsort: true
                },
                autoBind: true,
                pageable: true
            };
        };
        FacilityController.$inject = ['$scope', '$window', '$http', '$q'];
        return FacilityController;
    }());
    Spartan.FacilityController = FacilityController;
    var app = angular.module("Spartan");
    app.controller("facilitycontroller", FacilityController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=FacilityCtrl.js.map