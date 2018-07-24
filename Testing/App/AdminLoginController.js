uiroute.controller('AdminLoginController', function ($scope, $http, $state) {
    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.BaseUrl = 'http://localhost:50497/api/Administrators';

    $scope.LoginData = {
        Email: '',
        Password: '',
        Id: ''
    };

    //Check is Form Valid or Not // Here f1 is our form Name
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });

    $scope.Login = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            $http.post($scope.BaseUrl + '/UserLogin', $scope.LoginData).
                then(function (response) {
                    if (response.data == "") {
                        alert("incorrect email/password");
                    }
                    else {
                        //alert("Successfull");
                        $scope.IsLogedIn = true;
                        localStorage.setItem('admin', JSON.stringify(response.data));
                        $state.go('AdminDashBoard');
                    }
                }, function () { alert("failed"); });
            //AdminLoginService.GetUser($scope.LoginData).then(function (d) {                
            //    $scope.IsLogedIn = true;
            //    localStorage.setItem('admin', JSON.stringify(d.data));
            //    $state.go('AdminDashBoard');//go to dashboard                
            //});
        }
    };

});
