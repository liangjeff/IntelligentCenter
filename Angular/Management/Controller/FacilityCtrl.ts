module Spartan {
    "use strict";

    export class FacilityController {
        public gridDatasource = new kendo.data.DataSource();

        static $inject = ['$scope', '$window', '$http', '$q'];

        constructor(
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService) {

            this.gridDatasource.pageSize(20);
            this.q.all({
                getCarparkList: this.http.get("/Management/Facility/GetCarparkList")
            }).then((d) => {
                var list = d["getCarparkList"].data;
                this.gridDatasource.data(list);
            }).finally(() => {

            });
        }

        public mainGridOptions(): kendo.ui.GridOptions {
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
        }
    }

    var app = angular.module("Spartan");
    app.controller("facilitycontroller", FacilityController);
}