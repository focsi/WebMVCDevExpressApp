var myApp = angular.module('myApp', ['dx']);
myApp.controller("gridCtrl", function ($scope,$http) {

    $scope.elemekSzama = 10;
    //$scope.elemiMunkakList = [];
    var SERVICE_URL = "http://localhost:59588/api/elemimunkak";

    var store = new DevExpress.data.CustomStore({
        totalCount: function (loadOptions) { //Required if your data service does not allow return this value in a single request.
            var d = new $.Deferred();
            var params = {};
            //Getting filter options
            if (loadOptions.filter) {
                params.filter = JSON.stringify(loadOptions.filter);
            }
            params.needCount = true; //You can use this parameter on the server side to ensure that a number of records is required

            $http.get(SERVICE_URL + "/totalCount")
                .then ( function (data) {
                    d.resolve(data.data, { totalCount: data.data });
                },function (error) {
                    d.reject(error);
                });
            return d.promise();;
        },

        load: function (loadOptions) {
            var d = new $.Deferred();

            var params = {};
            ////Getting filter options
            //if (loadOptions.filter) {
            //    params.filter = JSON.stringify(loadOptions.filter);
            //}
            ////Getting sort options
            //if (loadOptions.sort) {
            //    params.sort = JSON.stringify(loadOptions.sort);
            //}
            //skip and take are used for paging
            params.skip = loadOptions.skip; //A number of records that should be skipped
            params.take = loadOptions.take; //A number of records that should be taken

            $http.get(SERVICE_URL, { params: params })
                .then(function (data) {
                    d.resolve(data.data);
                }, function (error) {
                    d.reject(error);
                });
            return d.promise();;
        },

        byKey: function (key) {
            return $.getJSON(SERVICE_URL + "/" + encodeURIComponent(key));
        },

        insert: function (values) {
            return $.post(SERVICE_URL, values);
        },

        update: function (key, values) {
            return $.ajax({
                url: SERVICE_URL + "/" + encodeURIComponent(key),
                method: "PUT",
                data: values
            });
        },

        remove: function (key) {
            return $.ajax({
                url: SERVICE_URL + "/" + encodeURIComponent(key),
                method: "DELETE",
            });
        }

    });
    $scope.elemiMunkakList= new DevExpress.data.DataSource({
        store: store
    });

    //$scope.elemekSzamaChanged = function () {
    //    $http.get("/api/elemimunkak/" + $scope.elemekSzama).success(function (data, status, headers, config) {
    //        console.log("gridCtrl success");

    //        for (index in data) {
    //            $scope.elemiMunkakList.push(data[index]);
    //        }

    //    }).error(function (data, status, headers, config) {
    //        console.log("gridCtrl Hiba: " + data);
    //    });
    //}
});
