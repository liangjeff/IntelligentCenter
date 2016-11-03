var Spartan;
(function (Spartan) {
    "use strict";
    var AccountController = (function () {
        function AccountController(scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.onSaveClick = function () {
                _this.http.post("/Account/UpdateUserProfile", { profile: _this.userProfile })
                    .then(function (response) {
                    if (response) {
                        console.log('success');
                    }
                    else {
                        console.log('failed');
                    }
                }).finally(function () {
                });
            };
            this.q.all({
                getUserProfile: this.http.get("/Account/GetUserProfile?id=" + currentUserId)
            }).then(function (d) {
                _this.userProfile = d["getUserProfile"].data;
            }).finally(function () {
            });
            this.test = "this is test";
        }
        AccountController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId'];
        return AccountController;
    }());
    Spartan.AccountController = AccountController;
    var app = angular.module("Spartan");
    app.controller("accountController", AccountController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=AccountCtrl.js.map