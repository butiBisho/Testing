uiroute.controller('ClientController', function ($scope, $http) { 
    var details = JSON.parse(localStorage.getItem('admin'));
    $scope.Email = details[0].Email;
    $scope.BaseUrl = 'http://localhost:50497/api';

    GetAll();
    function GetAll() {
        $http.get($scope.BaseUrl + '/clients/').then(function (response) { alert("Succesfull!"); $scope.Clients = response.data }, function () { alert("Failed To Get"); });
    }

    $scope.adminDelClientById = function (id) {        
        confirm("Do you want to delete client account?");

        $http.delete($scope.BaseUrl + '/clients/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully"); 
            GetAll();
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    }    
});