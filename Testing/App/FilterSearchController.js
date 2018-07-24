uiroute.controller('FilterSearchController', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.tasks = JSON.parse(localStorage.getItem('requestedData'));
    $scope.BaseUrl = 'http://localhost:50497/api';

    $http.get($scope.BaseUrl + '/Flights/' + $scope.tasks.departureLocation.trim() + '/' + $scope.tasks.arrivalLocation.trim() + '/' + $scope.tasks.departureDate.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        var dds = response.data;
        $scope.flights = dds;
        //console.log(dds);
    });

    $scope.FlightSelected = function (selData) {
        localStorage.setItem('FlightDetails', JSON.stringify(selData));
        $state.go('Traveller');
    };

    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;

    $scope.TotalTravellers = parseInt($scope.tasks.adults) + parseInt($scope.tasks.children) + parseInt($scope.tasks.infants);
    localStorage.setItem('TotalTravellers', JSON.stringify(parseInt($scope.tasks.adults) + parseInt($scope.tasks.children) + parseInt($scope.tasks.infants)));

}]);
   
   




