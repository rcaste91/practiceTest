app.controller("MyController", function ($scope, $http) {
    /*
    return $http({
        method: 'GET',
        url: '/api/HomeModel',
        then: $scope.Student = res.data
    })
    */

    
    $http.get("/api/HomeModel")
        .then(function (res) {
            console.log(res);
            $scope.Student = res.data;
            
        });
    
});