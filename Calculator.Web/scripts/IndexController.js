angularApp.controller('indexController', ['$scope', 'ExpressionDataService',
    function indexController($scope, ExpressionDataService) {
        $scope.expression = '1+2+3+4';
        $scope.totalSum = '10';
        $scope.hasError = false;
        $scope.errorMessage = '';
        $scope.isCalculating = false;

        $scope.calculateClick = function () {
            $scope.hasError = false;
            $scope.errorMessage = '';
            $scope.isCalculating = true;

            ExpressionDataService.parseExpression($scope.expression,
                function (result) {
                    $scope.totalSum = result.data.TotalSum;
                    if (result.data.IsValid === false) {
                        $scope.hasError = true;
                        $scope.errorMessage = 'The given expression cannot be parsed';
                    }

                    $scope.isCalculating = false;
                },
                function(result) {
                    $scope.hasError = true;
                    $scope.errorMessage = 'A problem occurred while calculating the total. This could be due to an invalid expression or a server error';
                    $scope.isCalculating = false;
                });
        }
    }]);

angularApp.factory('ExpressionDataService', ["$http", function ($http) {
    var parseExpression = function (expression, success, failure) {
        var url = '/home/ProcessValue';

        var data = {
            Value: expression
        };

        $http.post(url, data).then(
            function (result) {
                success(result);
            },
            function (result) {
                failure(result);
            });
    }

    return {
        parseExpression: parseExpression
    }
}]);