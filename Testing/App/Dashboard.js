uiroute.controller('Dashboard', function ($scope, $http, $state) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.FirstName = details[0].FirstName;
    $scope.Surname = details[0].Surname;
    $scope.BaseUrl = 'http://localhost:50497/api';

    GetClientbyID();
    function GetClientbyID() {
        //alert("get client by id");
        $http.get($scope.BaseUrl + '/Clients/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.Client = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.DelClientById = function (id) {
        confirm("Do you want to delete account?");

        $http.delete($scope.BaseUrl + '/Clients/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
            $state.go('Index');
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };
    $scope.IsHidden = true;
    $scope.ClientDetails = { ClientId: "", Title: "", FirstName: "", Surname: "", Email: "", Password: "" };
    $scope.GetClientById = function (id) {
        $http.get($scope.BaseUrl + '/Clients/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.ClientDetails = dds[0];
            console.log(dds[0]);
        });
        $scope.IsHidden = $scope.IsHidden ? false : true;
    };

    function ClientList() {
        return $http.get($scope.BaseUrl + '/Clients/').then(function (response) { $scope.Client = response.data; });
    }

    $scope.updateClient = function (formdata) {
        confirm("Are you sure you want to update Client Id : " + formdata.ClientId.toString());
        $http.put($scope.BaseUrl + '/Clients/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllClients();
        }, function () {
            alert("Failed update record");
        });
    };

});