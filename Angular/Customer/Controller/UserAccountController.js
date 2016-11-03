var Spartan;
(function (Spartan) {
    "use strict";
    var UserAccountController = (function () {
        function UserAccountController(//构造函数
            scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.UserAccountDatasource = new kendo.data.DataSource();
            this.CurrentUserId = currentUserId; //
            this.UserAccountDatasource.pageSize(20); //每页显示20页
            this.q.all({
                getUserAccount: this.http.get("/Customer/UserAccount/GetMyAccount?userId=" + currentUserId) //先从数据库获得数据   //GetMyCars是什么
            }).then(function (d) {
                _this.UserAccountDatasource.data(d["getUserAccount"].data);
            }).finally(function () {
            });
        }
        UserAccountController.prototype.AccountGridOptions = function () {
            return {
                dataSource: this.UserAccountDatasource,
                columns: [
                    { title: "ID", field: "Id" },
                    { title: "Account Type", field: "AccountType" },
                    { title: "Account Number", field: "AccountNumber" },
                    { title: "CVV", field: "CVV" },
                ],
                sortable: {
                    mode: "multiple",
                    allowUnsort: true
                },
                autoBind: true,
                pageable: true
            };
        };
        UserAccountController.prototype.TransactionGridOptions = function () {
            return {
                dataSource: this.UserAccountDatasource,
                columns: [
                    //{ title: "ID", field: "Id" },
                    //{ title: "Account Type", field: "AccountType" },
                    //{ title: "Account Number", field: "AccountNumber" },
                    //{ title: "CVV", field: "CVV" },
                    { title: "CarName", field: "CarName" },
                    { title: "CarparkName", field: "CarparkName" },
                    { title: "Duration", field: "Duration" },
                    { title: "TotalAmount", field: "TotalAmount" },
                    { title: "Pay From", field: "PayFrom" },
                    { title: "Pay To", field: "PayTo" },
                ],
                sortable: {
                    mode: "multiple",
                    allowUnsort: true
                },
                autoBind: true,
                pageable: true
            };
        };
        UserAccountController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return UserAccountController;
    }());
    Spartan.UserAccountController = UserAccountController;
    var app = angular.module("Spartan");
    app.controller("useraccountcontroller", UserAccountController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=UserAccountController.js.map