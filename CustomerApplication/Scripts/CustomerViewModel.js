angular.module("CustomerApplication")
.controller("CustomerViewModel",
    function CustomerViewModel($scope) {

        $scope.Customer = {
            "CustomerCode": "",
            "CustomerName": "",
            "CustomerDob": "",
            "CustomerAmount": "",
            "CustomerAmountColor": ""
        };

        $scope.GetColor = function (Amount) {
            if (Amount == 0) {
                return "";
            }
            else if (Amount >= 10000) {
                return "Aqua";
            }
            else {
                return "Yellow";
            }
        };

        $scope.$watch("Customer.CustomerAmount", function () {
            $scope.Customer.CustomerAmountColor = $scope.GetColor($scope.Customer.CustomerAmount);
        });

    });

