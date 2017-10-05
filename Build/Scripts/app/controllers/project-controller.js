
app.controller('ProjectCtrl', function ($scope, $http) {

    $scope.answered = false;
    $scope.title = "loading question...";
    $scope.options = [];
    $scope.correctAnswer = false;
    $scope.working = false;

    $scope.Project = {
        Id: 0,
        Name: '',
        Image: '',
        Status: 1
    };

    $scope.Clear = function () {
        $scope.Project.Id = 0,
        $scope.Project.Name = '',
        $scope.Project.Image = '',
        $scope.Project.Status = 1
    };

    $scope.StatusList = [
     {
         id: 1,
         name: 'Active'
     }, {
         id: 2,
         name: 'Delete'
     }];

    $scope.GetAll = function () {

        var response = $http({
            method: "get",
            url: "api/Projects",
            data: $scope.Project,
        });

        response.then(function (data) {
            console.log(data.data);
            $scope.ProjectList = data.data;
        });
    };

    $scope.AddUpdateProject = function () {

        var response = $http({
            method: "post",
            url: "api/Projects/AddUpdate",
            data: $scope.Project,
        });

        response.then(function () {
            $scope.GetAll();
            $scope.Clear();

            $scope.message = "Project saved";

            setTimeout(function () {
                $scope.message = "";
            }, 5000);

        }, function () {
            alert('Error..');
        });


    };

    $scope.EditRow = function (id) {

        var response = $http({
            method: "get",
            url: "api/Projects/Find/" + id,
            data: id,
        });

        response.then(function (data) {

            $scope.Clear();

            $scope.Project = data.data;

            var status = $scope.StatusList.filter(function (el) {
                return el.name === $scope.Project.Status
            });

            $scope.Project.Status = status && status.length > 0 ? status[0].id : 1;

            console.log($scope.Project)

        }, function () {
            alert('Error..');
        });


    };

    $scope.DeleteRow = function (id) {

        bootbox.confirm("Are you sure? You want to delete this item!", function (result) {
            if (result) {
                var response = $http({
                    method: "post",
                    url: "api/Projects/Delete/" + id,
                    data: id,
                });

                response.then(function (data) {

                    $scope.GetAll();
                    $scope.Clear();

                    $scope.message = "Project item removed.";

                    setTimeout(function () {
                        $scope.message = "";
                    }, 5000);

                }, function () {
                    alert('Error..');
                });
            }
        });


    };

    $scope.GetAll();
});