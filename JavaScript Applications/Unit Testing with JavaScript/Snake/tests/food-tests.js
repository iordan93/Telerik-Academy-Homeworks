/// <reference path="../QUnit/qunit-1.11.0.js" />
/// <reference path="../scripts/snake.js" />

module("Food");

test("Food is created properly", function () {
    var food = new snakeGame.Food();
    notEqual(food, null, "Food is not null");
    notEqual(food, undefined, "Food is defined");
});

test("Food constructor creates all fields properly", function () {
    var position = {
        x: 150,
        y: 150
    };

    var food = new snakeGame.Food(position, 10);

    equal(food.position.x, position.x, "Food position relative to the X axis OK");
    equal(food.position.y, position.y, "Food position relative to the X axis OK");
    equal(food.size, 10, "Food size OK");
    equal(food.fcolor, "#0000ff", "Food fill colour OK");
    equal(food.scolor, "#00ff00", "Food stroke colour OK");
});

test("Food changes position properly", function () {
    var position = {
        x: 150,
        y: 150
    };
    var newPosition = {
        x: 160,
        y:160
    };
    var food = new snakeGame.Food(position, 10);
    food.changePosition(newPosition);
    equal(food.position.x, newPosition.x, "Food position relative to the X axis changed");
    equal(food.position.y, newPosition.y, "Food position relative to the X axis changed");
    equal(food.size, 10, "Food size not changed during position change");
});