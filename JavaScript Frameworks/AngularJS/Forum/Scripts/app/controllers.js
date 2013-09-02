/// <reference path="../libs/angular.js" />
/// <reference path="../libs/underscore.js" />

function PostsController($scope, $http) {

    var categoryId = 0;

    $scope.newPost = {
        title: "",
        content: "",
        category: ""
    };

    $http.get("/api/posts")
		.success(function (posts) {
		    $scope.posts = posts;
		    $scope.categories = _.uniq(_.pluck(posts, "category"));
		    $scope.selectedCategory = $scope.categories[categoryId];
		});

    $scope.addPost = function () {

        var data = {
            content: $scope.newPost.content,
            category: $scope.newPost.category
        };

        $http.post("/api/posts", JSON.stringify(data));

        $scope.newPost = {
            title: "",
            content: "",
            category: ""
        };
    }
}

function CategoriesController($scope, $http, $routeParams) {

    var categoryId = $routeParams ? $routeParams.categoryId : 0;

    $http.get("/api/posts")
		.success(function (posts) {
		    $scope.posts = posts;
		    $scope.categories = _.uniq(_.pluck(posts, "category"));
		    $scope.selectedCategory = $scope.categories[categoryId];
		});
}
