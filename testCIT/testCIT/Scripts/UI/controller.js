(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller', controller);

    controller.$inject = ['$scope', '$http', '$location'];

    function controller($scope, $http, $location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'controller';

        $scope.myData = [
            {
                firstName: "Cox",
                lastName: "Carney",
                company: "Enormo",
                employed: true
            },
            {
                firstName: "Lorraine",
                lastName: "Wise",
                company: "Comveyer",
                employed: false
            },
            {
                firstName: "Nancy",
                lastName: "Waters",
                company: "Fuelton",
                employed: false
            }
        ];

        $scope.onTmpButtonClick = function() {
            alert("Works");
        }


        $http.get($location.$$absUrl + '/api/values').then(function(responce) {
            var a = responce.data;
        });


        $http({ method: 'GET', url: $location.$$absUrl + '/api/values' }).
            success(function (data, status, headers, config) {
                // this callback will be called asynchronously
                // when the response is available
                var a = data;
            });

        activate();

        function activate() { }
    }
})();
