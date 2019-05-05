(function () {
    'use strict';


    angular.module('app').controller('ModalInstanceCtrl', function ($uibModalInstance, $http,$scope, item) {
        var $ctrl = this;
        $scope.items = JSON.parse(JSON.stringify(item));


        $ctrl.ok = function () {
            $uibModalInstance.close($scope.items);
        };

        $ctrl.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        $scope.groupsList = {};

        $http.get('api/group').then(function (responce) {
            $scope.groupsList = responce.data;
            if ($scope.groupsList != undefined && $scope.items.GroupId === 0) {
                $scope.items.GroupId = $scope.groupsList[0].Id;
            }
        });


    });

    angular.module('app')
        .directive('convertToNumber', function () {
            return {
                require: 'ngModel',
                link: function (scope, element, attrs, ngModel) {
                    ngModel.$parsers.push(function (val) {
                        return parseInt(val, 10);
                    });
                    ngModel.$formatters.push(function (val) {
                        return '' + val;
                    });
                }
            };
        });
})();
