uiroute.controller('Return', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.tasks = JSON.parse(localStorage.getItem('requestedData'));
    $scope.BaseUrl = 'http://localhost:50497/api';
        
    $http.get($scope.BaseUrl + '/Flights/' + $scope.tasks.departureLocation.trim() + '/' + $scope.tasks.arrivalLocation.trim() + '/' + $scope.tasks.departureDate.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        var dds = response.data;
        $scope.flights = dds;
        //console.log(dds);
    });

    $http.get($scope.BaseUrl + '/Flights/' + $scope.tasks.arrivalLocation.trim() + '/' + $scope.tasks.departureLocation.trim() + '/' + $scope.tasks.arrivalDate.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        var rrs = response.data;
        $scope.ReturnFlights = rrs;
        //console.log(dds);
    });

    $scope.GetFromDetails = function (formdata, e) {
        if (e.target.checked) {
            $state.go('Register');
        }   
    };

    $scope.GetToDetails = function (formdata, e) {
        if (e.target.checked) {
            $state.go('Register');
        }
    };

    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;

    $scope.TotalTravellers = parseInt($scope.tasks.adults) + parseInt($scope.tasks.children) + parseInt($scope.tasks.infants);
    localStorage.setItem('TotalTravellers', JSON.stringify(parseInt($scope.tasks.adults) + parseInt($scope.tasks.children) + parseInt($scope.tasks.infants)));

}]);