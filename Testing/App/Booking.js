uiroute.controller('Booking', function ($scope, $http) {
    var details = JSON.parse(localStorage.getItem('username'));  
    $scope.Email = details[0].Email; 
    $scope.BaseUrl = 'http://localhost:50497/api';

    //Flight start
    GetFlightBookingsByClientID();
    function GetFlightBookingsByClientID() {
        $http.get($scope.BaseUrl + '/Client_Flight/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.FlightBookings = response.data; localStorage.setItem('flightBooking', JSON.stringify(response.data)); }, function () { alert("Failed To Get"); });
    }  

    $scope.DelFlightBookingById = function (id) {
        confirm("Do you want to delete Booking?");

        $http.delete($scope.BaseUrl + '/Client_Flight/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };    
    //Flight ends
    //Car starts
    GetCarBookingsByClientID();
    function GetCarBookingsByClientID() {
        $http.get($scope.BaseUrl + '/Client_Car/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.CarBookings = response.data; localStorage.setItem('CarBooking', JSON.stringify(response.data)); }, function () { alert("Failed To Get"); });
    }

    $scope.DelCarBookingById = function (id) {
        confirm("Do you want to delete Booking?");

        $http.delete($scope.BaseUrl + '/Client_Car/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };
    //Car ends
    //Hotel starts
    GetHotelBookingsByClientID();
    function GetHotelBookingsByClientID() {
        $http.get($scope.BaseUrl + '/Client_Hotel/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.HotelBookings = response.data; localStorage.setItem('HotelBooking', JSON.stringify(response.data)); }, function () { alert("Failed To Get"); });
    }

    $scope.DelhotelBookingById = function (id) {
        confirm("Do you want to delete Booking?");

        $http.delete($scope.BaseUrl + '/Client_Hotel/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };
    //Hotel ends
});