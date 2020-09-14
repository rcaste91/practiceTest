app.controller("MyController", function ($scope, $http,$location) {

    
    $http.get("/api/HomeModel")
        .then(function (res) {
            console.log(res);
            $scope.Student = res.data;
            
        });
    
});