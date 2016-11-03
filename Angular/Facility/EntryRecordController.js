var Spartan;
(function (Spartan) {
    "use strict";
    var EntryRecordController = (function () {
        function EntryRecordController(//构造函数
            scope, window, http, q, currentUserId) {
            var _this = this;
            this.scope = scope;
            this.window = window;
            this.http = http;
            this.q = q;
            this.currentUserId = currentUserId;
            this.CurrentUserId = currentUserId; //
            this.q.all({
                getentryrecord: this.http.get("/Facility/EntryRecord/GetEntryRecord")
            }).then(function (d) {
                _this.EntryRecordDataSource = d["getentryrecord"].data;
            }).finally(function () {
            });
        }
        EntryRecordController.$inject = ['$scope', '$window', '$http', '$q', 'currentUserId']; //注入元素   包括id
        return EntryRecordController;
    }());
    Spartan.EntryRecordController = EntryRecordController;
    var app = angular.module("Spartan");
    app.controller("entryrecordcontroller", EntryRecordController);
})(Spartan || (Spartan = {}));
//# sourceMappingURL=EntryRecordController.js.map