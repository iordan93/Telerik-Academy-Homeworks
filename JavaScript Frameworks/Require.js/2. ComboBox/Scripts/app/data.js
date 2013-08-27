define(function () {
    var people = [
        { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "Images/man.png" },
        { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "Images/man.png" },
        { id: 3, name: "Asya Grigorova", age: 20, avatarUrl: "Images/woman.png" },
        { id: 4, name: "Ivanka Ivanova", age: 20, avatarUrl: "Images/woman.png" }
    ];

    var getPeople = function (success) {
        success(people);
    };

    return {
        getPeople: getPeople
    }
});