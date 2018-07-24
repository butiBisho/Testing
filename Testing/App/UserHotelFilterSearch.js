uiroute.controller('UserHotelFilterSearch', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.tasks = JSON.parse(localStorage.getItem('HotelRequestedData'));
    $scope.BaseUrl = 'http://localhost:50497/api';

    $http.get($scope.BaseUrl + '/values/' + $scope.tasks.destination.trim()).then(function (response) {
        $scope.search = {};
        $scope.searchBy = '$';
        $scope.hotels = response.data;
    });

    $scope.HotelSelected = function (selData) {
        localStorage.setItem('HotelDetails', JSON.stringify(selData));
        $state.go('UserSelectRoom');
    };

    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;

    //localStorage.setItem('TotalPartners', JSON.stringify(parseInt($scope.tasks.adults) + parseInt($scope.tasks.children)));

}]);
