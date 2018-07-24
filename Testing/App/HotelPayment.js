uiroute.controller('HotelPayment', function ($scope, $timeout, $state, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';
    $scope.BaseUrlEmail = "/Data/SendMailToUser";

    //$scope.total = JSON.parse(localStorage.getItem('TotalTravellers'));
    //$scope.details = JSON.parse(localStorage.getItem('FlightDetails'));
    var bookings = JSON.parse(localStorage.getItem('HotelBooking'));
    $scope.DateCreated = bookings[0].DateCreated;
    $scope.Status = bookings[0].Status;
    $scope.ClientId = bookings[0].ClientId;
    $scope.HotelId = bookings[0].HotelId;
    $scope.TotalCost = bookings[0].TotalCost;
    $scope.CH_Id = bookings[0].CH_Id;

    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;

    $scope.HotelPayment = {
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
        CH_Id: ''
    };

    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });

    $scope.SaveData = function (data) {
        if ($scope.submitText == 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $scope.HotelPayment = data;
                $scope.HotelPayment.clientId = $scope.Id;
                $scope.HotelPayment.CH_Id = $scope.CH_Id;
                $http.post($scope.BaseUrl + '/HotelPayments', $scope.HotelPayment).then(function (response) { $scope.submitText = 'Saved'; alert("Successfully Saved"); ClearForm(); }, function () { alert("failed"); });
                $scope.blnPayed = true;
                sendEmail();
                updateBooking();
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }        
    };
    $scope.emailBody = "<p>Hi,<br/>Your payment transaction was successfull.Your Hotel Room number is we32.Thank you for using TravelStart.<br />Regards TravelStart Admin</p>";
    $scope.subject = "TravelStart Payment Confirmation";

    //send email    
    function sendEmail() {
        if ($scope.blnPayed === true) {
            $http({
                method: "POST",
                url: $scope.BaseUrlEmail,
                dataType: 'json',
                data: { mailAddress: $scope.Email, subject: $scope.subject, emailBody: $scope.emailBody },
                headers: { "Content-Type": "application/json" }
            }).then(function (response) { alert("An Email will send shortly for payment confirmation"); }, function () { alert("failed"); });
        }
    }
    //update client_Hotel room
    $scope.HotelBooking = {
        DateCreated: '',
        Status: '',
        ClientId: '',
        HotelId: '',
        TotalCost: '',
        CH_Id: ''
    };

    function updateBooking() {
        $scope.HotelBooking.DateCreated = $scope.DateCreated;
        $scope.HotelBooking.Status = "Payment made";
        $scope.HotelBooking.ClientId = $scope.ClientId;
        $scope.HotelBooking.HotelId = $scope.HotelId;
        $scope.HotelBooking.TotalCost = $scope.TotalCost;
        $scope.HotelBooking.CH_Id = $scope.CH_Id;

        $http.put($scope.BaseUrl + '/Client_Hotel/', $scope.HotelBooking).then(function () {
            //alert("Successfully Updated!");            
        });
    }

    function ClearForm() {
        $scope.HotelPayment = {};
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