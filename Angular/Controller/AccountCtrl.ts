module Spartan {
    "use strict";

    export class AccountController {
        public userProfile: IUserProfile;
        public test: string;

        

        static $inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];

        constructor(
            private scope: any,
            private window: ng.IWindowService,
            private http: ng.IHttpService,
            private q: ng.IQService,
            private currentUserId: string) {

            this.q.all({
                getUserProfile: this.http.get("/Account/GetUserProfile?id=" + currentUserId)
            }).then((d) => {
                this.userProfile = d["getUserProfile"].data;
            }).finally(() => {

                });
            this.test = "this is test";
        }
     
        

        public onSaveClick = () => {
            this.http.post("/Account/UpdateUserProfile", { profile: this.userProfile})
                .then(response => {
                    if (response) {
                        console.log('success');
                    } else {
                        console.log('failed');
                    }
                }).finally(() => {

                });
        }
    }

    var app = angular.module("Spartan");
    app.controller("accountController", AccountController);

    export interface IUserProfile {
        Id: string;
        UserId: string;
        FirstName: string;
        LastName: string;
        Salutation: string;
        JobTitle: boolean;
        ContactNumber: string;
        Email: string;
    }
}