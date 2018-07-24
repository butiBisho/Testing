uiroute.controller('HotelRegister', function ($scope, $timeout, $state, $http) { //explained about controller in Part 2
    //Default Variable
    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.BaseUrl = 'http://localhost:50497/api';

    $scope.Client = {
        Title: '',
        FirstName: '',
        Surname: '',
        Email: '',
        Password: ''
    };
    //Check form Validation // here f1 is our form name
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    //Save Data
    $scope.SaveData = function (data) {
        if ($scope.submitText === 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $scope.Client = data;
                $http.post($scope.BaseUrl + '/Clients', $scope.Client).then(function (response) { alert("Successfull"); $scope.submitText = 'Saved'; $state.go('HotelLogin'); }, function () { alert("failed"); });
                //RegistrationService.SaveFormData($scope.Client).then(function (response) {
                //    $scope.message = "saved successfully!!";
                //    $state.go('Login');
                //});
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    };
    //Clear Form (reset)
    function ClearForm() {
        $scope.Client = {};
        $scope.f1.$setPristine(); //here f1 our form name
        $scope.submitted = false;
    }
});