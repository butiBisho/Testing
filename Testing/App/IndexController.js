uiroute.controller('IndexController', ['$scope', '$http', '$state', function ($scope, $http, $state) {
    $scope.BaseUrl = 'http://localhost:50497/api';
    $http.get($scope.BaseUrl + '/Locations').then(function (response) {
        $scope.locations = response.data;
    });
    $scope.requestedData = {
        departureLocation: '',
        arrivalLocation: '',
        departureDate: '',
        arrivalDate: '',
        adults: '',
        children: '',
        infants: ''
    };

    $scope.radioStatus = 0;
    $scope.saveSelectedData = function (data) {
        $scope.requestedData = data;
        localStorage.setItem('requestedData', JSON.stringify($scope.requestedData));
        console.log($scope.requestedData);
        localStorage.setItem('radioStatus', JSON.stringify($scope.radioStatus));

        if ($scope.radioStatus === 0) {
            $state.go('UserFilterSearch');
        }
        else {
            $state.go('UserReturn');
        }
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