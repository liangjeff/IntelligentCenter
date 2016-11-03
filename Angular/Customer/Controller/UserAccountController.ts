module Spartan {
    "use strict";

    export class UserAccountController {
        public UserAccountDatasource = new kendo.data.DataSource();
        public CurrentUserId: string;

        static $inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];//注入元素   包括id

        constructor(//构造函数
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService,
            private currentUserId: string) {

            this.CurrentUserId = currentUserId;//

            this.UserAccountDatasource.pageSize(20);//每页显示20页

            this.q.all({
                getUserAccount: this.http.get("/Customer/UserAccount/GetMyAccount?userId=" + currentUserId)//先从数据库获得数据   //GetMyCars是什么
            }).then((d) => {
                this.UserAccountDatasource.data(d["getUserAccount"].data);
            }).finally(() => {

            });
        }

        public AccountGridOptions(): kendo.ui.GridOptions {//kendo 框架
            return {
                dataSource: this.UserAccountDatasource,
                columns: [//显示得元素
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
        }
        public TransactionGridOptions(): kendo.ui.GridOptions {//kendo 框架
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
        }
    }
    var app = angular.module("Spartan");
    app.controller("useraccountcontroller", UserAccountController);
}