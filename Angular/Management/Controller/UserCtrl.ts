module Spartan {
    "use strict";

    export class UserController {
        public gridDatasource = new kendo.data.DataSource();

        static $inject = ['$scope', '$window', '$http', '$q'];

        constructor(
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService) {

            this.gridDatasource.pageSize(20);
            this.q.all({
                getUserList: this.http.get("/Management/User/GetUserList")
            }).then((d) => {
                var list = d["getUserList"].data;
                this.gridDatasource.data(list);
            }).finally(() => {

            });
        }

        public mainGridOptions(): kendo.ui.GridOptions {
            return {
                dataSource: this.gridDatasource,
                columns: [
                    { title: "ID", field: "UserId" },
                    { title: "First Name", field: "FirstName" },
                    { title: "Last Name", field: "LastName" },
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
    app.controller("userController", UserController);
}