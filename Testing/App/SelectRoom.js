uiroute.controller('SelectRoom', ['$scope', '$http', '$state', function ($scope, $http, $state) {
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
    //$http.post('/Data/GetImageByRoomNumberName', "we32").then(function (response) { console.log(response.data); $scope.image = response.data; }, function () { alert("failed"); });

    $scope.HotelSelected = function (selData) {
        localStorage.setItem('RoomDetails', JSON.stringify(selData));
        $state.go('Partner');
    };

    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;

    localStorage.setItem('TotalPartners', JSON.stringify(parseInt($scope.tasks.adults) + parseInt($scope.tasks.children)));

}]);
