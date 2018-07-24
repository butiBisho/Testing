uiroute.controller('ExtrasController', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    var details = JSON.parse(localStorage.getItem('username'));
    console.log(details[0].Email + " === " + details[0].ClientId);
    $scope.Email = details[0].Email;
    $scope.Travellers = JSON.parse(localStorage.getItem('TotalTravellers'));    
    $scope.PriceTo = JSON.parse(localStorage.getItem('FlightToDetails'));    
    //$scope.Id = details[0].ClientId;
    $scope.details = JSON.parse(localStorage.getItem('FlightDetails'));
    $scope.BaseUrl = 'http://localhost:50497/api';    

    $http.get($scope.BaseUrl + '/Extras').then(function (response) {
        $scope.extras = response.data;
    });

    var blnRadio = JSON.parse(localStorage.getItem('btnRadio'));
    function myFunc() {
        var TotalAmt = $scope.details.Price * $scope.Travellers;
        if (blnRadio == 1) {
            TotalAmt = ($scope.details.Price + $scope.PriceTo.Price) * $scope.Travellers;
        }
        return TotalAmt;
    };
    $scope.Total = myFunc();
    console.log($scope.Total);
    //$scope.Total = $scope.details.Price;
    $scope.msg = "Add To Booking";
    $scope.GetPrice = function (price, e) {
        if (e.target.checked) {
            $scope.Total = $scope.Total + parseInt(price);
            alert("Total is " + $scope.Total);
            $scope.msg = "Remove";
        }
        else {
            $scope.Total = $scope.Total - parseInt(price);
            alert("Total is " + $scope.Total);   
            $scope.msg = "Add To Booking";
        }
    };
    $scope.Booking = {
        DateCreated: '',
        Status: '',
        ClientId: '',
        FlightId: '',
        TotalCost: ''
    };
    $scope.MakeBooking = function () {
        $scope.Booking.DateCreated = new Date();
        $scope.Booking.Status = "Pending";
        $scope.Booking.ClientId = details[0].ClientId;
        $scope.Booking.FlightId = $scope.details.FlightId;
        $scope.Booking.TotalCost = $scope.Total;

        $http.post($scope.BaseUrl + '/Client_Flight', $scope.Booking).then(function (response) { alert("Successfully Booked"); }, function () { alert("failed"); });
    };

    if ($scope.details.AirlineName.trim() == "FlySafair") {
        $scope.img = "../../flight/FlySAFair.png";
    } else if ($scope.details.AirlineName.trim() == "Mango") {
        $scope.img = "../../flight/Mango.png";
    }

    $scope.SendEmail = function () {//email for payment confirmation
        //alert($scope.Email);
        //$http.post('/Data/SendMailToUser').then(function (response) { alert("Success"); }, function () { alert("failed"); });
        $http({
            method: "POST",
            url: "/Data/SendMailToUser",
            dataType: 'json',
            data: { mailAddress: $scope.Email },
            headers: { "Content-Type": "application/json" }
        }).then(function (response) { alert("Success"); }, function () { alert("failed"); });
    };
    
}]);