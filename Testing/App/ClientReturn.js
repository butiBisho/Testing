uiroute.controller('ClientReturn', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.tasks = JSON.parse(localStorage.getItem('requestedData'));
    $scope.BaseUrl = 'http://localhost:50497/api';
    $scope.FromPrice = 0;
    $scope.ToPrice = 0;

    $http.get($scope.BaseUrl + '/Flights/' + $scope.tasks.departureLocation.trim() + '/' + $scope.tasks.arrivalLocation.trim() + '/' + $scope.tasks.departureDate.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        var dds = response.data;
        $scope.flights = dds;
        $scope.FromPrice = dds.Price;
        //console.log(dds);
    });

    $http.get($scope.BaseUrl + '/Flights/' + $scope.tasks.arrivalLocation.trim() + '/' + $scope.tasks.departureLocation.trim() + '/' + $scope.tasks.arrivalDate.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        var rrs = response.data;
        $scope.ReturnFlights = rrs;
        $scope.ToPrice = rrs.Price;
        //console.log(dds);
    });

    $scope.SelectedFlights = {
        DepartureTime: '',
        ArrivalTime: '',
        DepartureLocation: '',
        ArrivalLocation: '',
        Stops: '',
        Price: '',
        AirL_ID: '',
        FlightDate: '',        
        TotalSeats: '',
        SeatsLeft: '',
        AirlineName: '',
        AdminID: ''
    };

    $scope.SelectedFlightsTo = {
        DepartureTime: '',
        ArrivalTime: '',
        DepartureLocation: '',
        ArrivalLocation: '',
        Stops: '',
        Price: '',
        AirL_ID: '',
        FlightDate: '',        
        TotalSeats: '',
        SeatsLeft: '',
        AirlineName: '',
        AdminID: ''
    };
    
    $scope.showgraphSidebar = false;
    $scope.GetFromDetails = function (formdata) {
        localStorage.setItem('FlightDetails', JSON.stringify(formdata));  
        $scope.showgraphSidebar = !$scope.showgraphSidebar;
        //display formadata
        $scope.SelectedFlights = formdata;
    };

    $scope.GetToDetails = function (formdata) {
        localStorage.setItem('FlightToDetails', JSON.stringify(formdata)); 
        $scope.showgraphSidebar = !$scope.showgraphSidebar;
        //display formadata
        $scope.SelectedFlightsTo = formdata;
    };
    
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;

    $scope.TotalTravellers = parseInt($scope.tasks.adults) + parseInt($scope.tasks.children) + parseInt($scope.tasks.infants);
    localStorage.setItem('TotalTravellers', JSON.stringify($scope.TotalTravellers));

}]);