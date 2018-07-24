uiroute.controller('CarIndexController', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.BaseUrl = 'http://localhost:50497/api';
    $http.get($scope.BaseUrl + '/Locations').then(function (response) {
        $scope.locations = response.data;
    });
    $scope.requestedData = {
        pickUp: '',
        dropOff: '',
        pickUpDate: '',
        pickUpTime: '',
        dropOffDate: '',
        dropOffTime: ''
    };

    $scope.saveSelectedData = function (data) {
        $scope.requestedData = data;
        localStorage.setItem('CarRequestedData', JSON.stringify($scope.requestedData));
        $state.go('UserFilterCar');
    };
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
