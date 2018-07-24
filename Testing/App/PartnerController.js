uiroute.controller('PartnerController', function ($scope, $timeout, $state, $http) { //explained about controller in Part 2
    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].ClientId;
    $scope.BaseUrl = 'http://localhost:50497/api';
        
    $scope.HotelDetails = JSON.parse(localStorage.getItem('HotelDetails'));    
    $scope.RoomDetails = JSON.parse(localStorage.getItem('RoomDetails'));
    //console.log($scope.RoomDetails.Name);
    $scope.tasks = JSON.parse(localStorage.getItem('HotelRequestedData'));
    var rooms = $scope.tasks.rooms;
    var checkIn = $scope.tasks.checkIn;
    var checkOut = $scope.tasks.checkOut;

    var difference = parseInt(checkOut.substring(8, checkOut.length)) - parseInt(checkIn.substring(8, checkIn.length));
    var cost = $scope.RoomDetails.Price * $scope.tasks.rooms;    
    $scope.TotalCost = cost * difference;    
    //Default Variable
    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.Partner = {
        FirstName: '',
        LastName: '',
        ClientId: ''
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
                $scope.Partner = data;
                $scope.Partner.ClientId = $scope.Id;
                $http.post($scope.BaseUrl + '/Partners/', $scope.Partner).then(function (response) { $scope.submitText = 'Saved'; ClearForm(); $scope.message = 'Successfully Saved'; }, function () { alert("failed"); });
            }
            else {
                $scope.message = 'Please fill required fields value';
            }
        }
    }

    if ($scope.HotelDetails.Name.trim() == "ghggggg") {
        $scope.img = "../../hotel/ghggggg.jpg";
    } else if ($scope.HotelDetails.Name.trim() == "sdfggdf") {
        $scope.img = "../../hotel/sdfggdf.jpg";
    }

    if ($scope.RoomDetails.RoomNumber.trim() == "we32") {
        $scope.imgRoom = "../../hotel/pic3.jpg";
    } else if ($scope.RoomDetails.RoomNumber.trim() == "we33") {
        $scope.imgRoom = "../../hotel/timthumb (1).jpg";
    }

    //Clear Form (reset)
    function ClearForm() {
        $scope.Partner = {};
        $scope.f1.$setPristine(); //here f1 our form name
        $scope.submitted = false;
    }

    $scope.Booking = {
        DateCreated: '',
        Status: '',
        TotalCost: '',
        ClientId: '',
        HotelId: ''
    };

    $scope.MakeBooking = function () {
        $scope.Booking.DateCreated = new Date();
        $scope.Booking.Status = "Pending";
        $scope.Booking.TotalCost = $scope.TotalCost;
        $scope.Booking.ClientId = details[0].ClientId;
        $scope.Booking.HotelId = $scope.HotelDetails.HotelID;

        $http.post($scope.BaseUrl + '/Client_Hotel', $scope.Booking).then(function (response) { alert("Successfully Booked"); }, function () { alert("failed"); });
        updateHotel();
    };

    $scope.formdata = {
        Name: '',
        TelNumber: '',
        StarRating: '',
        NumberOfRooms: '',
        LocationId: '',
        AdminID: '',
        RoomsLeft: ''
    };
    function updateHotel() {
        //update hotel table
        //get numberOfRooms
        $scope.formdata.Name = $scope.HotelDetails.Name;
        $scope.formdata.TelNumber = $scope.HotelDetails.TelNumber;
        $scope.formdata.StarRating = $scope.HotelDetails.StarRating;
        $scope.formdata.NumberOfRooms = $scope.HotelDetails.NumberOfRooms;
        $scope.formdata.LocationId = $scope.HotelDetails.LocationId;
        $scope.formdata.AdminID = $scope.HotelDetails.AdminID;
        $scope.formdata.RoomsLeft = parseInt($scope.HotelDetails.RoomsLeft) + 1;        

        $http.put($scope.BaseUrl + '/Hotels/', $scope.formdata).then(function () {
            alert("Successfully Updated!");
        }, function () {
            alert("Failed update record");
        });
    }

});