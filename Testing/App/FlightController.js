uiroute.controller('FlightController', ['$scope', '$http', FlightController]);
function FlightController($scope, $http) {
    $scope.loading = true;
    $scope.updateShow = false;
    $scope.addShow = true;
    $scope.BaseUrl = 'http://localhost:50497/api';

    $http.get($scope.BaseUrl + '/flights').then(function (data) {
        $scope.flights = data;
    });
    $scope.add = function () {
        $scope.submitText = "Save";
        $scope.submitted = false;
        $scope.isFormValid = false;
        $scope.$watch('f1.$valid', function (newValue) {
            $scope.isFormValid = newValue;
        });
        $scope.loading = true;
        if ($scope.submitText == 'Save') {
            $scope.submitted = true;
            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $http.post($scope.BaseUrl + '/flights/', this.newflight).then(function (data) {
                    $scope.flights = data;
                    $scope.updateShow = false;
                    $scope.addShow = true;
                    $scope.newflight = '';
                });
            }
        }
        
    }
    $scope.edit = function () {
        var Id = this.flight.FlightId;
        $http.get($scope.BaseUrl + '/flights/' + Id).then(function (data) {
            $scope.newflight = data;
            $scope.updateShow = true;
            $scope.addShow = false;
        });
    }
    $scope.update = function () {
        $scope.loading = true;
        console.log(this.newflight);
        $http.put($scope.BaseUrl + '/flights/', this.newflight).then(function (data) {
            $scope.flights = data;
            $scope.updateShow = false;
            $scope.addShow = true;
            $scope.newflight = '';
        });
    }
    $scope.delete = function () {
        var Id = this.flight.FlightId;
        $scope.loading = true;
        $http.delete($scope.BaseUrl + '/flights/' + Id).then(function (data) {
            $scope.flights = data;
        });
    }
    $scope.cancel = function () {
        $scope.updateShow = false;
        $scope.addShow = true;
        $scope.newflight = '';
    }
}