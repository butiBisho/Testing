uiroute.controller('Bisho', function ($scope, $http) {
    var details = JSON.parse(localStorage.getItem('admin'));
    $scope.Email = details[0].Email;
    $scope.FirstName = details[0].FirstName;
    $scope.Surname = details[0].Surname;

    GetAll();
    function GetAll() {
        alert("get admin by id");
        $http.get('http://localhost:50497/api/administrators/' + details[0].AdminId).then(function (response) { alert("Succesfull!"); $scope.Administrator = response.data; }, function () { alert("Failed To Get"); });
    };

    $scope.adminDelById = function (id) {
        confirm("Do you want to delete account?");

        $http.delete('http://localhost:50497/api/administrators/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
            $state.go('Index');
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.HideAdmin = true;
    $scope.AdminDetails = { AdminId: "", Title: "", FirstName: "", Surname: "", Email: "", Password: "" };
    $scope.adminGetById = function (id) {
        alert(id);
        $http.get('http://localhost:50497/api/administrators/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.AdminDetails = dds[0];
            console.log(dds[0]);
        });
        $scope.HideAdmin = $scope.HideAdmin ? false : true;
    };

    function AdminList() {
        return $http.get('http://localhost:50497/api/administrators/').then(function (response) { $scope.Administrator = response.data; });
    };

    $scope.updateAdmin = function (formdata) {
        confirm("Are you sure you want to update Admin Id : " + formdata.AdminId.toString());
        $http.put('http://localhost:50497/api/administrators/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAll();
        }, function () {
            alert("Failed update record");
        });
    };
});