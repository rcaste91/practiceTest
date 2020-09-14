app.controller("ListController", function ($scope, $http, $location) {

    $http.get("/api/ListModel")
        .then(function (res) {
            $scope.Users = res.data;
        });

    $scope.getdetails = function (name,username,email) {

        
        search = {
            sName : name,
            sUsername : username,
            sEmail : email
        };
 
        $http.post("/api/ListModel/search", JSON.stringify(search))
            .then(function (res) {
                $scope.Users = res.data;
            });
    }

    $scope.seeAlbums = function () {

        $location.path('/Albums')
        /*
        $http.post("/api/HomeModel")
            .then(function (res) {
                console.log(res);
            });
            */
    }

});