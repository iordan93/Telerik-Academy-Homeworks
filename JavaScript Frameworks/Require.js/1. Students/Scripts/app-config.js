/// <reference path="libs/require.js" />
require.config({
	paths: {
		jquery: "libs/jquery-2.0.3",
		rsvp: "libs/rsvp.min",
		httpRequester: "libs/http-requester",
		mustache: "libs/mustache"
	}
});

require(["jquery","mustache", "app/data-persister", "app/controls"], function ($, mustache, data, controls) {
    var students;

    // get all students using web services
    // url - http://localhost:64324/api/students
    data.getStudents()
		.then(function (people) {
		    students = people;
		    var personTemplateString = $("#student-template").html();

			var template = mustache.compile(personTemplateString);

			var listView = controls.listView(people);
			var listViewHtml = listView.render(template);
			document.getElementById("content").innerHTML = listViewHtml;

		}, function (err) {
			console.error(err);
		});

    $("#content").on("click", "li", function () {
        var studentId = $(this).find("div").attr('id');
        console.log(    studentId);
        data.getMarks(studentId)
		.then(function (marks) {
		    var marksTemplateString = $("#marks-template").html();

		    var template = mustache.compile(marksTemplateString);

		    var listView = controls.listView(marks);
		    var listViewHtml = listView.render(template);
		    document.getElementById("content").innerHTML = listViewHtml;

		}, function (err) {
		    console.error(err);
		});        
    })

    //$("#content").on("click", "li", function () {
    //    var marksTemplateString = $("#marks-template").html();

    //    var marksTemplate = mustache.compile(marksTemplateString);

    //    var listView = controls.listView(students);

    //    var studentId = $(this).find("div").attr('id');
    //    var listViewHtml = listView.renderMarks(marksTemplate, studentId - 1);
    //    document.getElementById("content").innerHTML = listViewHtml;
    //})

    //$("#ul").on("click", "li", function () {
    //    $(this).siblings().hide();
    //});
});