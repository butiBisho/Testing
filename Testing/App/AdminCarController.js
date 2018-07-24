uiroute.controller('AdminCarController', function ($scope, $http, FileUploadService) {
    var details = JSON.parse(localStorage.getItem('admin'));
    $scope.Email = details[0].Email;
    $scope.Id = details[0].AdminId;
    $scope.FirstName = details[0].FirstName;
    $scope.Surname = details[0].Surname;
    $scope.BaseUrl = 'http://localhost:50497/api';
    //Cars start
    GetAllCars();
    function GetAllCars() {
        $http.get($scope.BaseUrl + '/PartNine/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Cars = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.Car = {
        Name: '',
        Mileage: '',
        Price: '',
        SpecialOffer: '',
        CarSpecifications: '',
        Transmission: '',
        SupplierID: '',
        Location: '',
        Date: '',
        AdminID: '',
        TotalCars: '',
        CarsLeft: ''
    };
    $scope.HideAddSupplier = true;
    $scope.showInsert = function () {
        $scope.HideAddSupplier = $scope.HideAddSupplier ? false : true;
    };

    $scope.InsertAdminCar = function (data) {
        $scope.Car = data;
        $scope.Car.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Cars', $scope.Car).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllCars();
    };

    $scope.HideCar = true;
    $scope.Vehicle = { CarId: "", Name: "", Mileage: "", Price: "", SpecialOffer: "", CarSpecifications: "", Transmission: "", SupplierID: "", Location: "", Date: "", AdminID: "", TotalCars: "", CarsLeft: "" };
    $scope.GetCarById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Cars/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Vehicle = dds[0];
            console.log(dds[0]);
        });
        $scope.HideCar = $scope.HideCar ? false : true;
    };

    $scope.InsertCar = true;
    $scope.OpenInsertCar = function () {
        $scope.InsertCar = $scope.InsertCar ? false : true;
    };

    $scope.DelCarById = function (id) {
        confirm("Do you want to delete Car?");

        $http.delete($scope.BaseUrl + '/Cars/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateCar = function (formdata) {
        //alert(formdata.AdminID);
        confirm("Are you sure you want to update Car Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Cars/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllCars();
        }, function () {
            alert("Failed update record");
        });
    };
    //Cars ends
    //Suppliers starts
    GetAllSuppliers();
    function GetAllSuppliers() {
        $http.get($scope.BaseUrl + '/PartFour/' + $scope.Id.toString()).then(function (response) { /*alert("Succesfull!");*/ $scope.Suppliers = response.data; }, function () { alert("Failed To Get"); });
    }

    $scope.Supplier = {
        Name: '',
        AdminID: ''
    };

    $scope.InsertAdminSupplier = function (data) {
        $scope.Supplier = data;
        $scope.Supplier.AdminID = details[0].AdminId;
        $http.post($scope.BaseUrl + '/Suppliers', $scope.Supplier).then(function (response) { alert("Successfully inserted"); }, function () { alert("failed"); });
        GetAllSuppliers();
    };

    $scope.HideSupplier = true;
    $scope.Dealer = { SupplierId: "", Name: "", AdminID: "" };
    $scope.GetSupplierById = function (id) {
        //alert(id);
        $http.get($scope.BaseUrl + '/Suppliers/' + id.toString()).then(function (response) {
            var dds = response.data;
            $scope.Dealer = dds[0];
            console.log(dds[0]);
        });
        $scope.HideSupplier = $scope.HideSupplier ? false : true;
    };

    $scope.InsertSupplier = true;
    $scope.OpenInsertSupplier = function () {
        $scope.InsertSupplier = $scope.InsertSupplier ? false : true;
    };

    $scope.DelSupplierById = function (id) {
        confirm("Do you want to delete Supplier?");

        $http.delete($scope.BaseUrl + '/Suppliers/' + id.toString()).then(function (response) {
            $scope.colr = "#349d0a";
            alert("Deleted Successfully");
        }, function () {
            $scope.colr = "red";
            $scope.Status = "Failed to delete record";
        });
    };

    $scope.updateSupplier = function (formdata) {
        confirm("Are you sure you want to update Supplier Id : " + formdata.AdminID.toString());
        $http.put($scope.BaseUrl + '/Suppliers/', formdata).then(function () {
            alert("Successfully Updated!");
            GetAllSuppliers();
        }, function () {
            alert("Failed update record");
        });
    };
    //Suppliers ends
    //CarImage starts
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.FileCarName = "";
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
            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, $scope.FileCarName).then(function (d) {
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
    //CarImage ends
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

uiroute.factory('FileUploadService', function ($http, $q) {
    var fac = {};
    fac.UploadFile = function (file, description, carName) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);
        formData.append("carName", carName);

        var defer = $q.defer();
        $http.post("/Data/SaveCarFiles", formData,
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