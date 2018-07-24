uiroute.controller('TravellerController', function ($scope, $timeout, $state, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';

    $scope.total = JSON.parse(localStorage.getItem('TotalTravellers'));
    $scope.details = JSON.parse(localStorage.getItem('FlightDetails'));

    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;

    $scope.Traveller = {
        Title: '',
        FirstName: '',
        Surname: '',
        Email: '',
        MobileNumber: '',
        Day: '',
        Month: '',
        Year: '',
        clientId: ''
    };

    $scope.LoginData = {
        Email: '',
        Password: '',
        Id: ''
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
                $scope.Traveller = data;
                $scope.Traveller.clientId = $scope.Id;
                $http.post($scope.BaseUrl + '/Travellers', $scope.Traveller).then(function (response) { $scope.submitText = 'Saved'; ClearForm(); $scope.message = 'Successfully Saved'; }, function () { alert("failed"); });
                //TravellerService.SaveFormData($scope.Traveller).then(function (response) {
                //    ClearForm();
                //    $scope.submitText = "Saved";
                //});
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    }
    function ClearForm() {
        $scope.Traveller = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }

    if ($scope.details.AirlineName.trim() == "FlySafair") {
        $scope.img = "../../flight/FlySAFair.png";
    } else if ($scope.details.AirlineName.trim() == "Mango") {
        $scope.img = "../../flight/Mango.png";
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