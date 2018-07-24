uiroute.controller('FlightPayment', function ($scope, $timeout, $state, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';
    $scope.BaseUrlEmail = "/Data/SendMailToUser";
    $scope.FlightDetails = JSON.parse(localStorage.getItem('FlightDetails'));

    //$scope.total = JSON.parse(localStorage.getItem('TotalTravellers'));
    var bookings = JSON.parse(localStorage.getItem('flightBooking'));
    $scope.DateCreated = bookings[0].DateCreated;
    $scope.Status = bookings[0].Status;
    $scope.ClientId = bookings[0].ClientId;
    $scope.FlightId = bookings[0].FlightId;
    $scope.TotalCost = bookings[0].TotalCost;
    $scope.CF_Id = bookings[0].CF_Id;

    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;    

    $scope.FlightPayment = {
        CardNumber: '',
        NameOnCard: '',
        Month: '',
        Year: '',
        CVV: '',
        AddressLine1: '',
        AddressLine2: '',
        PostalCode: '',
        City: '',
        Country: '',
        ContactNumber: '',
        ClientId: '',
        CF_Id: ''
    };

    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    $scope.blnPayed = false;
    $scope.SaveData = function (data) {
        if ($scope.submitText === 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $scope.FlightPayment = data;
                $scope.FlightPayment.ClientId = $scope.ClientId;
                $scope.FlightPayment.CF_Id = $scope.CF_Id;
                $http.post($scope.BaseUrl + '/FlightPayments', $scope.FlightPayment).then(function (response) { $scope.submitText = 'Saved'; alert("Successfully Saved"); ClearForm(); }, function () { alert("failed"); });
                $scope.blnPayed = true;
                sendEmail();
                updateBooking();
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }        
    };
    //console.log($scope.FlightDetails.IATA);
    $scope.emailBody = "<p>Hi,<br/>Your payment transaction was successfull.Your Flight is TS2345.Thank you for using TravelStart.<br />Regards TravelStart Admin</p>";
    $scope.subject = "TravelStart Payment Confirmation";
    //send email
    function sendEmail() {
        if ($scope.blnPayed === true) {
            $http({
                method: "POST",
                url: $scope.BaseUrlEmail,
                dataType: 'json',
                data: { mailAddress: $scope.Email, subject: $scope.subject ,emailBody: $scope.emailBody },
                headers: { "Content-Type": "application/json" }
            }).then(function (response) { alert("An Email will send shortly for payment confirmation"); }, function () { alert("failed"); });
        }
    };

    //update client_flight
    $scope.FlightBooking = {
        DateCreated: '',
        Status: '',
        ClientId: '',
        FlightId: '',
        TotalCost: '',
        CF_Id: ''
    };

    function updateBooking() {
        $scope.FlightBooking.DateCreated = $scope.DateCreated;
        $scope.FlightBooking.Status = "Payment made";
        $scope.FlightBooking.ClientId = $scope.ClientId;
        $scope.FlightBooking.FlightId = $scope.FlightId;
        $scope.FlightBooking.TotalCost = $scope.TotalCost;
        $scope.FlightBooking.CF_Id = $scope.CF_Id;

        $http.put($scope.BaseUrl + '/Client_Flight/', $scope.FlightBooking).then(function () {
            //alert("Successfully Updated!");            
        });
    }

    function ClearForm() {
        $scope.FlightPayment = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }

});

uiroute.filter("minmax", function () {
    return function (arr, min, max) {
        min = parseInt(min);
        max = parseInt(max);
        for (var i = min; i <= max; i++) {
            arr.push(i);
        }
        return arr;
    };
});

uiroute.filter("year", function () {
    return function (arr, min, max) {
        min = parseInt(min);
        max = parseInt(max);
        for (var i = min; i <= max; i++) {
            arr.push(i);
        }
        return arr;
    };
});