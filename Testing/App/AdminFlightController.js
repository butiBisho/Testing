uiroute.controller('AdminFlightController', function ($scope, $http) {
    var details = JSON.parse(localStorage.getItem('admin'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].AdminId;
    $scope.FirstName = details[0].FirstName;
    $scope.Surname = details[0].Surname;
    $scope.BaseUrl = 'http://localhost:50497/api';
    //Locations start
    GetAllLocations();
    function GetAllLocations() {
        $http.get($scope.BaseUrl + '/PartFive/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Locations = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.Loc = {
        AirportName: '',
        City: '',
        Country: '',
        IATA: '',
        AdminId: ''
    };

    $scope.InsertAdminLocation = function (data) {
        $scope.Loc = data;
        $scope.Loc.AdminId = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Locations', $scope.Loc).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllLocations();
    };

    $scope.HideLocation = true;
    $scope.Port = { LocationId: "", AirportName: "", City: "", Country: "", IATA: "", AdminId: "" };
    $scope.GetLocById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Locations/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Port = dds[0];
            console.log(dds[0]);
        });
        $scope.HideLocation = $scope.HideLocation ? false : true;
    };

    $scope.InsertLocation = true;
    $scope.OpenInsertAirport = function () {
        $scope.InsertLocation = $scope.InsertLocation ? false : true;
    };

    $scope.DelLocById = function (id) {
        confirm("Do you want to delete airport?");

        $http.delete($scope.BaseUrl + '/Locations/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateLoc = function (formdata) {
        confirm("Are you sure you want to update Location Id : " + formdata.AdminId.toString());
        $http.put($scope.BaseUrl + '/Locations/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllLocations();
        }, function () {
            alert("Failed update record");
        });
    };
    //Locations ends
    //Extras starts
    GetAllExtras();
    function GetAllExtras() {
        $http.get($scope.BaseUrl + '/PartSix/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Extras = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.Extra = {
        Name: '',
        Price: '',
        Description: '',
        AdminId: ''
    };

    $scope.InsertAdminExtra = function (data) {
        $scope.Extra = data;
        $scope.Extra.AdminId = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Extras', $scope.Extra).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllExtras();
    };

    $scope.HideExtra = true;
    $scope.Plus = { ExtrasId: "", Name: "", Price: "", Description: "", AdminID: "" };
    $scope.GetExtraById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Extras/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Plus = dds[0];
            console.log(dds[0]);
        });
        $scope.HideExtra = $scope.HideExtra ? false : true;
    };

    $scope.InsertExtra = true;
    $scope.OpenInsertExtra = function () {
        $scope.InsertExtra = $scope.InsertExtra ? false : true;
    };

    $scope.DelExtraById = function (id) {
        confirm("Do you want to delete Extra?");

        $http.delete($scope.BaseUrl + '/Extras/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateExtra = function (formdata) {
        confirm("Are you sure you want to update Extra Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Extras/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllExtras();
        }, function () {
            alert("Failed update record");
        });
    };
    //Extras ends
    //Flight starts
    GetAllFlights();
    function GetAllFlights() {
        $http.get($scope.BaseUrl + '/PartEight/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Flights = response.data; }, function () { alert("Failed To Get"); });
    }
    $scope.Flight = {
        DepartureTime: '',
        ArrivalTime: '',
        DepartureLocation: '',
        ArrivalLocation: '',
        Stops: '',
        Price: '',
        AirL_ID: '',
        FlightDate: '',
        AdminID: '',
        TotalSeats: '',
        SeatsLeft: ''
    };

    $scope.InsertAdminFlight = function (data) {
        $scope.Flight = data;
        $scope.Flight.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Flights', $scope.Flight).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllFlights();
    };

    $scope.HideFlight = true;
    $scope.Seat = { FlightId: "", DepartureTime: "", ArrivalTime: "", DepartureLocation: "", ArrivalLocation: "", Stops: "", Price: "", AirL_ID: "", FlightDate: "", AdminID: "", TotalSeats: "", SeatsLeft: "" };
    $scope.GetFlightById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Flights/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Seat = dds[0];
            console.log(dds[0]);
        });
        $scope.HideFlight = $scope.HideFlight ? false : true;
    };

    $scope.InsertFlight = true;
    $scope.OpenInsertFlight = function () {
        $scope.InsertFlight = $scope.InsertFlight ? false : true;
    };

    $scope.DelFlightById = function (id) {
        confirm("Do you want to delete Flight?");

        $http.delete($scope.BaseUrl + '/Flights/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateFlight = function (formdata) {
        confirm("Are you sure you want to update Flight Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Flights/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllFlights();
        }, function () {
            alert("Failed update record");
        });
    };
    //get locations
    $http.get($scope.BaseUrl + '/Locations').then(function (response) {
        $scope.locations = response.data;
    });
    //Flight ends
    //Airline starts
    GetAllAirlines();
    function GetAllAirlines() {
        $http.get($scope.BaseUrl + '/PartSeven/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Airlines = response.data; }, function () { alert("Failed To Get"); });
    }
    $scope.Airline = {
        AirlineName: '',
        IATA: '',
        AdminID: ''
    };

    $scope.InsertAdminAirline = function (data) {
        $scope.Airline = data;
        $scope.Airline.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Airlines', $scope.Airline).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllExtras();
    };

    $scope.HideAirline = true;
    $scope.Supplier = { AirlineId: "", AirlineName: "", IATA: "", AdminID: "" };
    $scope.GetAirlineById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Airlines/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Supplier = dds[0];
            console.log(dds[0]);
        });
        $scope.HideAirline = $scope.HideAirline ? false : true;
    };

    $scope.InsertAirline = true;
    $scope.OpenInsertAirline = function () {
        $scope.InsertAirline = $scope.InsertAirline ? false : true;
    };
    
    $scope.DelAirlineById = function (id) {
        confirm("Do you want to delete Airline?");

        $http.delete($scope.BaseUrl + '/Airlines/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateAirline = function (formdata) {
        confirm("Are you sure you want to update Airline Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Airlines/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllAirlines();
        }, function () {
            alert("Failed update record");
        });
    };
    //Airline ends
});

uiroute.directive("datepicker", function () {
    function link(scope, element, attrs, controller) {
        element.datepicker({
            onSelect: function (val) {
                scope.$apply(function () {
                    controller.$setViewValue(val);
                });
            },
            dateFormat: "yy-mm-dd"
        });
    }
    return {
        require: 'ngModel',
        link: link
    };
});