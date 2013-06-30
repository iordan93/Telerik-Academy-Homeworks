/// <reference path="../QUnit/qunit-1.11.0.js" />
/// <reference path="../scripts/snake.js" />

module("MovingGameObject");

test("Moving game object is created properly", function () {
    var movingObject = new snakeGame.MovingGameObject();
    notEqual(movingObject, null, "MovingGameObject is not null");
    notEqual(movingObject, undefined, "MovingGameObject is defined");
});

test("Moving game object methods exist", function () {
    var movingObject = new snakeGame.MovingGameObject();
    notEqual(movingObject.init, null, "Constructor is defined");
    notEqual(movingObject.move, null, "move() is defined");
    notEqual(movingObject.changeDirection, null, "changeDirection() is defined");
});

test("Moving game object constructor works properly", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", 20, 0);

    equal(movingObject.position.x, position.x, "Position relative to the X axis OK");
    equal(movingObject.position.y, position.y, "Position relative to the Y axis OK");
    equal(movingObject.size, 5, "Size OK");
    equal(movingObject.fcolor, "green", "Fill colour OK");
    equal(movingObject.scolor, "red", "Stroke colour OK");
    equal(movingObject.speed, 20, "Speed OK");
    equal(movingObject.direction, 0, "Direction OK");
});

test("Moving game object move() method works properly - direction 0", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", 20, 0);

    movingObject.move();

    equal(movingObject.position.x, 30, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 150, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly - direction 1", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", 20, 1);

    movingObject.move();

    equal(movingObject.position.x, 50, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 130, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly - direction 2", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", 20, 2);

    movingObject.move();

    equal(movingObject.position.x, 70, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 150, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly - direction 3", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", 20, 3);

    movingObject.move();

    equal(movingObject.position.x, 50, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 170, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly with negative speed - direction 0", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 0);

    movingObject.move();

    equal(movingObject.position.x, 70, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 150, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly with negative speed - direction 1", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 1);

    movingObject.move();

    equal(movingObject.position.x, 50, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 170, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly with negative speed - direction 2", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 2);

    movingObject.move();

    equal(movingObject.position.x, 30, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 150, "Position relative to the Y axis changed properly");
});

test("Moving game object move() method works properly with negative speed - direction 3", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 3);

    movingObject.move();

    equal(movingObject.position.x, 50, "Position relative to the X axis changed properly");
    equal(movingObject.position.y, 130, "Position relative to the Y axis changed properly");
});

test("Moving game object changeDirection() method works properly - 0 to 1", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 0);

    movingObject.changeDirection(1);

    equal(movingObject.direction, 1, "Direction changed properly");
});

test("Moving game object changeDirection() method works properly - 1 to 2", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 1);

    movingObject.changeDirection(2);

    equal(movingObject.direction, 2, "Direction changed properly");
});

test("Moving game object changeDirection() method works properly - 3 to 2", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 3);

    movingObject.changeDirection(2);

    equal(movingObject.direction, 2, "Direction changed properly");
});

test("Moving game object changeDirection() method works properly - 0 to 2", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 0);

    movingObject.changeDirection(2);

    equal(movingObject.direction, 0, "Direction not changed");
    notEqual(movingObject.direction, 2, "Direction not changed");
});

test("Moving game object changeDirection() method works properly - 2 to 0", function () {
    var position = {
        x: 50,
        y: 150
    };
    var movingObject = new snakeGame.MovingGameObject(position, 5, "green", "red", -20, 2);

    movingObject.changeDirection(0);

    equal(movingObject.direction, 2, "Direction not changed");
    notEqual(movingObject.direction, 0, "Direction not changed");
});