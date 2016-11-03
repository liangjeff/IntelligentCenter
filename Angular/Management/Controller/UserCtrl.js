var Spartan;
(function (Spartan) {
    "use strict";
    var UserController = (function () {
        function UserController(scope, window, http, q) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.gridDatasource = new kendo.data.DataSource();
            this.gridDatasource.pageSize(20);
            this.q.all({
                getUserList: this.http.get("/Management/User/GetUserList")
            }).then(function (d) {
                var list = d["getUserList"].data;
                _this.gridDatasource.data(list);
            }).finally(function () {
            });
        }
        UserController.prototype.mainGridOptions = function () {
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
        };
        UserController.$inject = ['$scope', '$window', '$http', '$q'];
        return UserController;
    }());
    Spartan.UserController = UserController;
    var app = angular.module("Spartan");
    app.controller("userController", UserController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=UserCtrl.js.map