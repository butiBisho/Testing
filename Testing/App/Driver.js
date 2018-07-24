uiroute.controller('Driver', function ($scope, $timeout, $state, $http) {
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';

    //calculate date difference
    $scope.carDetails = JSON.parse(localStorage.getItem('CarDetails'));
    $scope.tasks = JSON.parse(localStorage.getItem('CarRequestedData'));
    var lastDay = $scope.tasks.dropOffDate;
    var firstDay = $scope.tasks.pickUpDate;
    
    var difference = parseInt(lastDay.substring(8, lastDay.length)) - parseInt(firstDay.substring(8, firstDay.length));
    var perc = parseInt($scope.carDetails.SpecialOffer) / 100;  
    $scope.TotalCost = (difference * parseInt($scope.carDetails.Price)) - ((difference * parseInt($scope.carDetails.Price)) * perc);

    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;

    $scope.Driver = {
        FirstName: '',
        Surname: '',
        Email: '',
        Phone: '',
        Address: '',
        City: '',
        PostCode: '',
        Country: '',
        FlightNumber: '',
        Age: '',
        ClientId: ''
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
        if ($scope.submitText === 'Save') {
            $scope.submitted = true;
            $scope.message = '';

            if ($scope.isFormValid) {
                $scope.submitText = 'Please Wait...';
                $scope.Driver = data;
                $scope.Driver.ClientId = $scope.Id;
                $http.post($scope.BaseUrl + '/Drivers/', $scope.Driver).then(function (response) { $scope.submitText = 'Saved'; ClearForm(); $scope.message = 'Successfully Saved'; }, function () { alert("failed"); });
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    };
    function ClearForm() {
        $scope.Driver = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }

    $scope.Booking = {
        DateCreated: '',
        Status: '',
        TotalCost: '',
        ClientId: '',
        CarId: ''
    };
    $scope.MakeBooking = function () {          
        $scope.Booking.DateCreated = new Date();
        $scope.Booking.Status = "Pending";
        $scope.Booking.TotalCost = $scope.TotalCost;
        $scope.Booking.ClientId = details[0].ClientId;
        $scope.Booking.CarId = $scope.carDetails.CarId;
                        
        $http.post($scope.BaseUrl + '/Client_Car', $scope.Booking).then(function (response) { alert("Successfully Booked"); }, function () { alert("failed"); });        
    };

    if ($scope.carDetails.Name.trim() == "chevrolet spark") {
        //alert($scope.carDetails.Name.trim());
        $scope.img = "../../car/car1.jpg";
    } else if ($scope.carDetails.Name.trim() == "dfgf") {
        $scope.img = "../../car/car4.jpg";
    } else if ($scope.carDetails.Name.trim() == "fghfghg") {
        $scope.img = "../../car/car3.jpg";
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