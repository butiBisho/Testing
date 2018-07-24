uiroute.controller('FlightPayment', function ($scope, $timeout, $state, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';
        
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

    $scope.SaveData = function (data) {
        if ($scope.submitText == 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $scope.FlightPayment = data;
                $scope.FlightPayment.ClientId = $scope.Id;
                $http.post($scope.BaseUrl + '/FlightPayments', $scope.FlightPayment).then(function (response) { $scope.submitText = 'Saved'; alert("Successfully Saved"); ClearForm(); }, function () { alert("failed"); });
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    };
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