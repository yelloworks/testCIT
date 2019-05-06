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

        $scope.deleteVisibility = true;


        $scope.groupsList = {};

        $http.get(window.location.origin +'/api/group').then(function (responce) {
            $scope.groupsList = responce.data;
            if ($scope.groupsList != undefined && $scope.items.GroupId === 0) {
                $scope.items.GroupId = $scope.groupsList[0].Id;
            }
        });

        $ctrl.delete = function() {
            $http.delete(window.location.origin + '/api/students/' + $scope.items.Id).then(function(responce) {
                $uibModalInstance.dismiss('delete');
            });
        }

        checkForDelete();

        function checkForDelete() {
            if ($scope.items.Id === 0) {
                $scope.deleteVisibility = false;
            }
        };

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
