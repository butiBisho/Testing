uiroute.controller('CarPayment', function ($scope, $timeout, $state, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';
    $scope.BaseUrlEmail = "/Data/SendMailToUser";

    //$scope.total = JSON.parse(localStorage.getItem('TotalTravellers'));
    //$scope.details = JSON.parse(localStorage.getItem('FlightDetails'));
    var cars = JSON.parse(localStorage.getItem('CarBooking'));
    $scope.DateCreated = cars[0].DateCreated;
    $scope.Status = cars[0].Status;
    $scope.ClientId = cars[0].ClientId;
    $scope.CarId = cars[0].CarId;
    $scope.TotalCost = cars[0].TotalCost;
    $scope.CC_Id = cars[0].CC_Id;

    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;

    $scope.CarPayment = {
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
        CC_Id: ''
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
                $scope.CarPayment = data;
                $scope.CarPayment.ClientId = $scope.ClientId;
                $scope.CarPayment.CC_Id = $scope.CC_Id;
                $http.post($scope.BaseUrl + '/CarPayments', $scope.CarPayment).then(function (response) { $scope.submitText = 'Saved'; alert("Successfully Saved"); ClearForm(); }, function () { alert("failed"); });
                $scope.blnPayed = true;
                sendEmail();
                updateBooking();
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    };

    $scope.emailBody = "<p>Hi,<br/>Your payment transaction was successfull.Your Car Rental receipt code is XXF985.Thank you for using TravelStart.<br />Regards TravelStart Admin</p>";
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
    //update client_car
    $scope.CarBooking = {
        DateCreated: '',
        Status: '',
        ClientId: '',
        CarId: '',
        TotalCost: '',
        CC_Id: ''
    };

    function updateBooking() {
        $scope.CarBooking.DateCreated = $scope.DateCreated;
        $scope.CarBooking.Status = "Payment made";
        $scope.CarBooking.ClientId = $scope.ClientId;
        $scope.CarBooking.CarId = $scope.CarId;
        $scope.CarBooking.TotalCost = $scope.TotalCost;
        $scope.CarBooking.CC_Id = $scope.CC_Id;

        $http.put($scope.BaseUrl + '/Client_Car/', $scope.CarBooking).then(function () {
            //alert("Successfully Updated!");            
        });
    }

    function ClearForm() {
        $scope.CarPayment = {};
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