uiroute.directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        });
    }
    return {
        link: fn_link
    };

}])
    .controller('fupController', function ($scope, $http) {
        var formdata = new FormData();
        $scope.BaseUrl = 'http://localhost:52272/Data';

        $scope.getTheFiles = function ($files) {
            $scope.imagesrc = [];
            for (var i = 0; i < $files.length; i++) {
                var reader = new FileReader();
                reader.fileName = $files[i].name;

                reader.onload = function (event) {
                    var image = {};
                    image.Name = event.target.fileName;
                    image.Size = (event.total / 1024).toFixed(2);
                    image.Src = event.target.result;
                    $scope.imagesrc.push(image);
                    $scope.$apply();
                };
                reader.readAsDataURL($files[i]);
            }
            angular.forEach($files, function (value, key) {
                formdata.append(key, value);
            });
        };

        $scope.uploadFiles = function () {
            var request = {
                method: 'POST',
                url: $scope.BaseUrl + '/SaveRoomFiles',
                data: formdata,
                headers: {
                    'Content-Type': undefined
                }
            };
            $http(request).success(function (d) {
                alert(d);
            }).error(function () {
                alert("Filled");
            })
        };

        $scope.reset = function () {
            angular.forEach(
                angular.element("input [type = 'file']"),
                function (inputElem) {
                    angular.element(inputElem).val(null);
                }
            );
            $scope.imagesrc = [];
            formdata = new FormData();
        };
        
        $scope.Testing = {
            FileName: '',
            Description: '',
            FilePath: '',
            RoomNumber: '',
            FileSize: ''
        };
        $http.get($scope.BaseUrl + '/GetImageByRoomNumberName').
            then(function (response) {
                //var details = response.data;
                $scope.Testing = response.data;
            }, function () { alert("failed"); }); 

        //$http.get('http://localhost:50497/api/Gallery').then(function (response) { alert("Successfull!"); $scope.images = response.data; console.log(response.data); }, function () { alert("Failed To Get"); });

    });