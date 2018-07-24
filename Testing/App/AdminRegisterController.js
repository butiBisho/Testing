uiroute.controller('AdminRegisterController', function ($scope, $timeout, $state, $http) { //explained about controller in Part 2
    //Default Variable
    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.BaseUrl = 'http://localhost:50497/api';

    $scope.Administrator = {
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
        if ($scope.submitText == 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $scope.Administrator = data;
                $http.post($scope.BaseUrl + '/Administrators', $scope.Administrator).then(function (response) { alert("Successfull"); $scope.submitText = 'Saved'; $state.go('AdminLogin'); }, function () { alert("failed"); });
                //AdminRegistrationService.SaveFormData($scope.Administrator).then(function (response) {
                //    $scope.message = "saved successfully!!";
                //    $state.go('AdminLogin');
                //});
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    }
    //Clear Form (reset)
    function ClearForm() {
        $scope.Client = {};
        $scope.f1.$setPristine(); //here f1 our form name
        $scope.submitted = false;
    }
});