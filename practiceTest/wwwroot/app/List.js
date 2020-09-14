app.controller("ListController", function ($scope, $http) {

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

        console.log(search);

        

        $http.post("/api/ListModel/search", JSON.stringify(search))
            .then(function (res) {
                $scope.Users = res.data;
            });
            

    }

});