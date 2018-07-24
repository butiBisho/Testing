uiroute.controller('AdminHotel', function ($scope, $http, FileUploadService, FileRoomUploadService) {
    var details = JSON.parse(localStorage.getItem('admin'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].AdminId;
    $scope.FirstName = details[0].FirstName;
    $scope.Surname = details[0].Surname;
    $scope.BaseUrl = 'http://localhost:50497/api';

    //Residence start
    GetAllResidences();
    function GetAllResidences() {
        $http.get($scope.BaseUrl + '/PartTen/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Residences = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.Residence = {
        StreetName: '',
        Code: '',
        City: '',
        Town: '',
        Country: ''
    };

    $scope.InsertResidence = function (data) {
        $scope.Residence = data;
        $scope.Residence.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Residences', $scope.Residence).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllResidences();
    };

    $scope.HideResidence = true;
    $scope.Loc = { LocationID: "", StreetName: "", Code: "", City: "", Town: "", Country: "", AdminID: "" };
    $scope.GetResidenceById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Residences/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Loc = dds[0];
            console.log(dds[0]);
        });
        $scope.HideResidence = $scope.HideResidence ? false : true;
    };

    $scope.DelResidenceById = function (id) {
        confirm("Do you want to delete Residence?");

        $http.delete($scope.BaseUrl + '/Residences/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateResidence = function (formdata) {
        confirm("Are you sure you want to update Residence Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Residences/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllResidences();
        }, function () {
            alert("Failed update record");
        });
    };
    //Residence ends
    //Hotel starts
    GetAllHotels();
    function GetAllHotels() {
        $http.get($scope.BaseUrl + '/PartEleven/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Hotels = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.Hotel = {
        Name: '',
        TelNumber: '',
        StarRating: '',
        NumberOfRooms: '',
        LocationId: '',
        AdminID: '',
        RoomsLeft: ''
    };

    $scope.InsertHotel = function (data) {
        $scope.Hotel = data;
        $scope.Hotel.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Hotels', $scope.Hotel).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllHotels();
    };

    $scope.HideHotel = true;
    $scope.Flat = { HotelID: "", Name: "", TelNumber: "", StarRating: "", NumberOfRooms: "", LocationId: "", AdminID: "", RoomsLeft: "" };
    $scope.GetHotelById = function (id) {
        $http.get($scope.BaseUrl + '/Hotels/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Flat = dds[0];
            console.log(dds[0]);
        });
        $scope.HideHotel = $scope.HideHotel ? false : true;
    };

    $scope.DelHotelById = function (id) {
        confirm("Do you want to delete Hotel?");

        $http.delete($scope.BaseUrl + '/Hotels/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateHotel = function (formdata) {
        confirm("Are you sure you want to update Hotel Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Hotels/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllHotels();
        }, function () {
            alert("Failed update record");
        });
    };
    //Hotel ends
    //Room starts
    GetAllRooms();
    function GetAllRooms() {
        $http.get($scope.BaseUrl + '/PartTwelve/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Rooms = response.data; }, function () { alert("Failed To Get"); });
    }
    $scope.Room = {
        AccommodationType: '',
        Facility: '',
        Theme: '',
        AccessibilityFeatures: '',
        Price: '',
        HotelId: '',
        RoomNumber: '',
        AdminID: ''
    };

    $scope.InsertRoom = function (data) {
        $scope.Room = data;
        $scope.Room.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Rooms', $scope.Room).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllRooms();
    };

    $scope.HideRoom = true;
    $scope.Space = { RoomID: "", AccommodationType: "", Facility: "", Theme: "", AccessibilityFeatures: "", Price: "", HotelId: "", RoomNumber: "", AdminID: "" };
    $scope.GetRoomById = function (id) {
        $http.get($scope.BaseUrl + '/Rooms/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Space = dds[0];
            console.log(dds[0]);
        });
        $scope.HideRoom = $scope.HideRoom ? false : true;
    };

    $scope.DelRoomById = function (id) {
        confirm("Do you want to delete Room?");

        $http.delete($scope.BaseUrl + '/Rooms/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateRoom = function (formdata) {
        confirm("Are you sure you want to update Room Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Rooms/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllRooms();
        }, function () {
            alert("Failed update record");
        });
    };
    //Room ends
    //Hotel Image starts
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.FileHotelName = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;
    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });
    //File Validation
    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload !== null) {
            if ((file.type === 'image/png' || file.type === 'image/jpeg' || file.type === 'image/gif') && file.size <= (512 * 1024)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    };
    //Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, $scope.FileHotelName).then(function (d) {
                alert(d.Message);
                ClearForm();
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };
    //Clear form 
    function ClearForm() {
        $scope.FileDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });
        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;
    }
    //Hotel Image ends
    //Room Image ends
    $scope.RoomMessage = "";
    $scope.RoomFileInvalidMessage = "";
    $scope.SelectedRoomFileForUpload = null;
    $scope.FileRoomDescription = "";
    $scope.FileRoomNumber = "";
    $scope.IsRoomFormSubmitted = false;
    $scope.IsRoomFileValid = false;
    $scope.IsRoomFormValid = false;
    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsRoomFormValid = isValid;
    });
    //File Validation
    $scope.IsChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedRoomFileForUpload !== null) {
            if ((file.type === 'image/png' || file.type === 'image/jpeg' || file.type === 'image/gif') && file.size <= (512 * 1024)) {
                $scope.RoomFileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.RoomFileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.RoomFileInvalidMessage = "Image required!";
        }
        $scope.IsRoomFileValid = isValid;
    };

    //File Select event 
    $scope.SelectedRoomFileForUpload = function (file) {
        $scope.SelectedRoomFileForUpload = file[0];
    };
    //Save File
    $scope.SaveRoomFile = function () {
        $scope.IsRoomFormSubmitted = true;
        $scope.RoomMessage = "";
        $scope.IsChechFileValid($scope.SelectedRoomFileForUpload);
        if ($scope.IsRoomFormValid && $scope.IsRoomFileValid) {
            FileRoomUploadService.UploadFile($scope.SelectedRoomFileForUpload, $scope.FileRoomDescription, $scope.FileRoomNumber).then(function (d) {
                alert(d.Message);
                ClearRoomForm();                
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.RoomMessage = "All the fields are required.";
        }
    };
    
    
    //Clear form 
    function ClearRoomForm() {
        $scope.FileRoomDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });
        $scope.f1.$setPristine();
        $scope.IsRoomFormSubmitted = false;
    }
    //Room Image ends
});
uiroute.factory('FileUploadService', function ($http, $q) {
    var fac = {};
    fac.UploadFile = function (file, description, hotelName) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);
        formData.append("hotelName", hotelName);

        var defer = $q.defer();
        $http.post("/Data/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
            .success(function (d) {
                defer.resolve(d);
            })
            .error(function () {
                defer.reject("File Upload Failed!");
            });
        return defer.promise;
    };
    return fac;
});

uiroute.factory('FileRoomUploadService', function ($http, $q) {
    var fac = {};
    fac.UploadFile = function (file, description, roomNumber) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);
        formData.append("roomNumber", roomNumber);

        var defer = $q.defer();
        $http.post("/Data/SaveRoomFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
            .success(function (d) {
                defer.resolve(d);
            })
            .error(function () {
                defer.reject("File Upload Failed!");
            });
        return defer.promise;
    };
    return fac;
});
