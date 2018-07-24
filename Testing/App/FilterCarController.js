uiroute.controller('FilterCarController', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.tasks = JSON.parse(localStorage.getItem('CarRequestedData'));
    $scope.BaseUrl = 'http://localhost:50497/api';

    $http.get($scope.BaseUrl + '/Cars/' + $scope.tasks.pickUp.trim() + '/' + $scope.tasks.pickUpDate.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        $scope.Cars = response.data;
    });

    $scope.CarSelected = function (selData) {
        localStorage.setItem('CarDetails', JSON.stringify(selData));
        $state.go('Driver');
    };

    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
}]);