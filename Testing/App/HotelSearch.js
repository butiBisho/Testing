uiroute.controller('HotelSearch', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.BaseUrl = 'http://localhost:50497/api';
    $http.get($scope.BaseUrl + '/Residences').then(function (response) {
        $scope.Residences = response.data;
    });
    $scope.requestedData = {
        destination: '',
        checkIn: '',
        checkOut: '',
        rooms: '',
        adults: '',
        children: ''
    };

    $scope.saveSelectedData = function (data) {
        $scope.requestedData = data;
        localStorage.setItem('HotelRequestedData', JSON.stringify($scope.requestedData));
        $state.go('HotelFilterSearch');
    };

    var details = JSON.parse(localStorage.getItem('username'));
    $scope.Email = details[0].Email;
}]);

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
