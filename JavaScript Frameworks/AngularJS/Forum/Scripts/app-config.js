/// <reference path="libs/angular.js" />
angular.module("forum", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
			.when("/", {
			    templateUrl: "Scripts/partials/all-posts.html",
			    controller: PostsController
			})
			.when("/byCategory", {
			    templateUrl: "Scripts/partials/posts-by-category.html",
			    controller: CategoriesController
			})
            .when("/add", {
                templateUrl: "Scripts/partials/add-post.html"
            })
			.otherwise({
			    redirectTo: "/"
			});
	}]);