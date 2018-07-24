uiroute.controller('UserSelectRoom', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.tasks = JSON.parse(localStorage.getItem('HotelRequestedData'));
    $scope.HotelDetails = JSON.parse(localStorage.getItem('HotelDetails'));
    $scope.BaseUrl = 'http://localhost:50497/api';

    $http.get($scope.BaseUrl + '/Flats/' + $scope.HotelDetails.Name).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        $scope.rooms = response.data;
    });

    $scope.UploadedFile = {
        HotelName: $scope.HotelDetails.Name
    };

    if ($scope.HotelDetails.Name.trim() == "ghggggg") {
        $scope.img = "../../hotel/ghggggg.jpg";
    } else if ($scope.HotelDetails.Name.trim() == "sdfggdf") {
        $scope.img = "../../hotel/sdfggdf.jpg";
    }
    //$http.post('/Data/GetImageByHotelName', $scope.UploadedFile).then(function (response) { console.log(response.data); $scope.FilePath = response.data.FilePath; }, function () { alert("failed"); });

    localStorage.setItem('TotalPartners', JSON.stringify(parseInt($scope.tasks.adults) + parseInt($scope.tasks.children)));

}]);
