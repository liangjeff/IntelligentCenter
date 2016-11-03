module Spartan {
    "use strict";

    export class IoTController {
        public gridDatasource = new kendo.data.DataSource();

        static $inject = ['$scope', '$window', '$http', '$q'];

        constructor(
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService) {

            this.gridDatasource.pageSize(20);
            this.q.all({
                getCarList: this.http.get("/Management/IoT/GetCarList")
            }).then((d) => {
                var list = d["getCarList"].data;
                this.gridDatasource.data(list);
            }).finally(() => {

            });
        }

        public mainGridOptions(): kendo.ui.GridOptions {
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
        }
    }

    var app = angular.module("Spartan");
    app.controller("iotcontroller", IoTController);
}