(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller', controller);

    controller.$inject = ['$scope', '$http', '$log', '$uibModal'];

    function controller($scope, $http, $log, $uibModal) {
        var $ctrl = this;
        $ctrl.title = 'controller';

        var apiControllerUrl = 'api/students';

        $scope.gridOptions = {
            showFooter: false,
            enableSorting: true,
            multiSelect: false,
            enableRowSelection: true,
            enableSelectAll: false,
            enableRowHeaderSelection: false,
            noUnselect: true,
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
            },
            appScopeProvider: {
                onDblClick: function (row) {
                    $ctrl.open((row.entity));
                }
            },
            rowTemplate: "<div ng-dblclick=\"grid.appScope.onDblClick(row)\" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell ></div>"
        }

        $scope.gridOptions.columnDefs = [
            { name: 'Name', displayName: 'Name' },
            { name: 'CurrentGroup.Name', displayName: 'Group' },
            { name: 'CurrentGroup.CurrentFaculty.Name', displayName: 'Faculty' }
        ];

        $scope.addItem = function() {
            var nullItem = {
                Id: 0, Name: "TmpName", GroupId: 0, CurrentGroup: null
            }
            $ctrl.open(nullItem);
        }


        $ctrl.open = function (item) {
            var modalInstance = $uibModal.open({
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                controllerAs: '$ctrl',
                resolve: {
                    item: function() {
                        return item;
                    }
                }
            });

            modalInstance.result.then(function (item) {
                if (item.Id !== 0) {
                    $http.put('api/students/' + item.Id, item).then(function(responce) {
                        getData();
                        $log.log("Done");
                    });
                } else {
                    $http.post('api/students/', item).then(function (responce) {
                        getData();
                        $log.log("Done");
                    });
                }
                

                $log.log(item);
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        getData();

        function getData() { $http.get(apiControllerUrl).then(function(responce) {
            $scope.gridOptions.data = responce.data;
        });}
    }
})();
