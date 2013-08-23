/// <reference path="underscore.js" />

var underscoreTasks = (function () {
    var getStudentsWithFirstBeforeLastName = function (students) {
        _.chain(students)
            .filter(function (s) {
                return s.firstName < s.lastName;
            })
                .sortBy(function (s) {
                    return s.toString();
                })
                    .reverse()
                        .each(function (s) {
                            console.log(s.toString());
                        });
    };

    var getStudentsAgedBetween18And24 = function (students) {
        _.chain(students)
            .filter(function (s) {
                return s.age >= 18 && s.age <= 24;
            })
                .each(function (s) {
                    console.log(s.toString());
                });
    };

    var getTheStudentWithHighestMarks = function (students) {
        var student = _.chain(students)
                    .max(function (s) {
                        var sum = 0;
                        var length = 0;
                        _.each(s.marks, function (marks) {
                            _.each(marks, function (m) {
                                sum += m;
                                length++;
                            })
                        });

                        return sum / length;
                    })
                        .value();

        console.log(student.toString());
    };

    var groupAnimalsBySpecies = function (animals) {
        _.chain(animals)
            .sortBy(function (a) {
                return a.legsCount;
            })
                .groupBy(function (a) {
                    return a.legsCount
                })
                    .each(function (a) {
                        _.each(a, function (a) {
                            console.log(a.name);
                        });
                        console.log("---");
                    })
    };

    var getTotalNumberOfLegs = function (animals) {
        var totalLegs = _.chain(animals).map(function (a) {
            return a.legsCount
        })
            .reduce(function (memo, num) {
                return memo + num
            })
                .value();

        console.log(totalLegs);
    };

    var findMostPopularAuthor = function (books) {
        var x = _.chain(books)
            .groupBy(function (b) {
                return b.author;
            })
                .sortBy(function (b) {
                    return b.length;
                })
                    .last()
                        .first()
                            .value();

        console.log(x.author);
    };

    var findMostCommonFirstName = function (people) {
        console.log(
            _.chain(people)
                .groupBy(function (p) {
                    return p.firstName;
                })
                    .max(function (g) {
                        return g.length;
                    })
                        .first()
                            .value()
                                .firstName);
    };

    var findMostCommonLastName = function (people) {
        console.log(
            _.chain(people)
                .groupBy(function (p) {
                    return p.lastName;
                })
                    .max(function (g) {
                        return g.length;
                    })
                        .first()
                            .value()
                                .lastName);
    };

    return {
        getStudentsWithFirstBeforeLastName: getStudentsWithFirstBeforeLastName,
        getStudentsAgedBetween18And24: getStudentsAgedBetween18And24,
        getTheStudentWithHighestMarks: getTheStudentWithHighestMarks,
        groupAnimalsBySpecies: groupAnimalsBySpecies,
        getTotalNumberOfLegs: getTotalNumberOfLegs,
        findMostPopularAuthor: findMostPopularAuthor,
        findMostCommonFirstName: findMostCommonFirstName,
        findMostCommonLastName: findMostCommonLastName
    };
})();