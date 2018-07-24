uiroute.controller('Additional', function ($scope, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;    
    $scope.BaseUrl = 'http://localhost:50497/api';
    //Traveller start
    GetTravellerBookingsByClientID();
    function GetTravellerBookingsByClientID() {
        $http.get($scope.BaseUrl + '/Travellers/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.Travellers = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.DelTravellerById = function (id) {
        confirm("Do you want to delete Traveller?");

        $http.delete($scope.BaseUrl + '/Travellers/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };
    $scope.IsHidden1 = true;
    $scope.TravellerDetails = { TravellerId: "", Title: "", FirstName: "", Surname: "", Email: "", MobileNumber: "", Day: "", Month: "", Year: "", ClientId: "" };
    $scope.GetTraveller = function (id) {        
        $http.get($scope.BaseUrl + '/Persons/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.TravellerDetails = dds[0];
            console.log(dds[0]);
        }, function () {
            alert("Failed");
        });
        $scope.IsHidden1 = $scope.IsHidden1 ? false : true;
    };

    $scope.updateTraveller = function (formdata) {
        confirm("Are you sure you want to update Traveller Id : " + formdata.TravellerId.toString());
        $http.put($scope.BaseUrl + '/Travellers/', formdata).then(function () {
            alert("Successfully Updated!");
            GetTravellerBookingsByClientID();
        }, function () {
            alert("Failed update record");
        });
    };
    //Traveller ends
    //Partner starts
    GetPartnerBookingsByClientID();
    function GetPartnerBookingsByClientID() {
        $http.get($scope.BaseUrl + '/Partners/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.Partners = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.DelPartnerById = function (id) {
        confirm("Do you want to delete Partner?");

        $http.delete($scope.BaseUrl + '/Partners/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };
    $scope.IsHidden2 = true;   
    $scope.PartnerDetails = { PartnerId: "", FirstName: "", LastName: "", ClientId: "" };
    $scope.GetPartner = function (id) {
        $http.get($scope.BaseUrl + '/PartThree/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.PartnerDetails = dds[0];
            console.log(dds[0]);
        }, function () {
            alert("Failed");
        });
        $scope.IsHidden2 = $scope.IsHidden2 ? false : true;
    };

    $scope.updatePartner = function (formdata) {
        confirm("Are you sure you want to update Partner Id : " + formdata.PartnerId.toString());
        $http.put($scope.BaseUrl + '/Partners/', formdata).then(function () {
            alert("Successfully Updated!");
            GetPartnerBookingsByClientID();
        }, function () {
            alert("Failed update record");
        });
    };
    //Partner ends
    //Driver starts
    GetDriverBookingsByClientID();
    function GetDriverBookingsByClientID() {
        $http.get($scope.BaseUrl + '/Drivers/' + details[0].ClientId).then(function (response) { /*alert("Succesfull!");*/ $scope.Drivers = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.DelDriverById = function (id) {
        confirm("Do you want to delete Driver?");

        $http.delete($scope.BaseUrl + '/Drivers/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };
    $scope.IsHidden3 = true;
    $scope.DriverDetails = { DriverId: "", FirstName: "", Surname: "", Email: "", Phone: "", Address: "", City: "", PostCode: "", Country: "", FlightNumber: "", Age: "", ClientId: "" };
    $scope.GetDriver = function (id) {
        $http.get($scope.BaseUrl + '/PartTwo/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.DriverDetails = dds[0];
            console.log(dds[0]);
        }, function () {
            alert("Failed");
        });
        $scope.IsHidden3 = $scope.IsHidden3 ? false : true;
    };

    $scope.updateDriver = function (formdata) {
        confirm("Are you sure you want to update Driver Id : " + formdata.DriverId.toString());
        $http.put($scope.BaseUrl + '/Drivers/', formdata).then(function () {
            alert("Successfully Updated!");
            GetDriverBookingsByClientID();
        }, function () {
            alert("Failed update record");
        });
    };
    //Driver ends
});