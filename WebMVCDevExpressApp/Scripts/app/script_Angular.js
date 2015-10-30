var myApp = angular.module('myApp', ['dx']);
myApp.controller("defaultCtrl", function ($scope) {
    $scope.randomValue = "0000000000";
    $scope.clickHandler = function () {
        var result = "";
        for (var i = 0; i < 10; i++) {
            result += Math.round(Math.random() * 9);
            $scope.randomValue = result;
        }
    };

    $scope.buttonDisabled = false;
});
