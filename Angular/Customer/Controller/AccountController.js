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
            this.myAccountDatasource = new kendo.data.DataSource(); //不清楚u    用不用修改 
            this.CurrentUserId = currentUserId; //
            this.myAccountDatasource.pageSize(20); //每页显示20页
            this.q.all({
                getUserAccount: this.http.get("/Customer/UserAccount/GetMyAccount?userId=" + currentUserId) //先从数据库获得数据   //GetMyCars是什么
            }).then(function (d) {
                _this.myAccountDatasource.data(d["getUserAccount"].data); //这个变量名还没有改
            }).finally(function () {
            });
        }
        UserAccountController.prototype.AccountGridOptions = function () {
            return {
                dataSource: this.myAccountDatasource,
                columns: [
                    { title: "ID", field: "Id" },
                    //  { title: "CarID", field: "CarID" },
                    { title: "Account Type", field: "AccountType" },
                    { title: "Type Name", field: "TypeName" },
                    { title: "Account Number", field: "AccountNumber" },
                    { title: "Expiry Date", field: "ExpireDate" },
                    { title: "CVV", field: "CVV" },
                    { title: "Transaction Time", field: "TransactionTime" },
                    { title: "Carpark Id", field: "CarparkId" },
                    { title: "Total Amount", field: "TotalAmount" },
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
    app.controller("accountcontroller", UserAccountController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=AccountController.js.map