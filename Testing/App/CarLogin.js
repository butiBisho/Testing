uiroute.controller('CarLogin', function ($scope, $state, $http) {
    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.BaseUrl = 'http://localhost:50497/api/Clients';

    $scope.LoginData = {
        Email: '',
        Password: '',
        Id: ''
    };

    //Check is Form Valid or Not // Here f1 is our form Name
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });

    $scope.CarLogin = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            $http.post($scope.BaseUrl + '/UserLogin', $scope.LoginData).
                then(function (response) {
                    if (response.data == "") {
                        alert("incorrect email/password");
                    } else {
                        //alert("Successfull");
                        $scope.IsLogedIn = true;
                        localStorage.setItem('username', JSON.stringify(response.data));
                        $state.go('CarSearch');
                    }
                }, function () { alert("failed"); });
        }
    };

});
