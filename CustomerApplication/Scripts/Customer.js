﻿function CustomerViewModel($scope, $http) {

    $scope.Customer = {
        "CustomerCode": "",
        "CustomerName": "",
        "CustomerDob": "",
        "CustomerAmount": "",
        "CustomerAmountColor": ""
    };

    $scope.Customers = {};

    $scope.$watch("Customers", function () {
        for (var x = 0; x < $scope.Customers.length; x++) {
            var cust = $scope.Customers[x];
            cust.CustomerAmountColor = $scope.getColor(cust.CustomerAmount);
        }
    });

    $scope.getColor = function (Amount) {
        if (Amount == 0) {
            return "";
        }
        else if (Amount > 100) {
            return "Blue";
        }
        else {
            return "Red";
        }
    }

    $scope.$watch("Customer.CustomerAmount", function () {
        $scope.Customer.CustomerAmountColor = $scope.
            getColor($scope.Customer.CustomerAmount);
    });

    $scope.Add = function () {
        // make a call to server to add data
        $http({ method: "POST", data: $scope.Customer, url: "SaveCustomer" }).
            then(function (response, status, headers, config) {
                $scope.Customers = response.data;
                // Load the collection of customer.
                $scope.Customer = {
                    "CustomerCode": "",
                    "CustomerName": "",
                    "CustomerDob": "",
                    "CustomerAmount": "",
                    "CustomerAmountColor": ""
                };
            });
    }

    $scope.Load = function () {
        debugger;
        $http({
            method: "GET",
            url: "GetCustomerJson"
        }).then(function (response) {
            $scope.Customers = response.data;
        },
               function errorCallback(response) {
                   // called asynchronously if an error occurs
                   // or server returns response with an error status.
               });
    }


    $scope.LoadByName = function () {
        debugger;
        $http({
            method: "POST",
            data: $scope.Customer,
            url: "GetCustomerByNameJson"
        }).then(function (response) {
            $scope.Customers = response.data;
        },
               function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
    }

    $scope.Load();
    // App
}