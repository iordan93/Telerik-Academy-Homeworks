/// <reference path="../QUnit/qunit-1.11.0.js" />
/// <reference path="../scripts/snake.js" />
module("Snake.init");

test("When snake is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    equal(position, snake.position, "Position is set");
    equal(speed, snake.speed, "Speed is set");
    equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);
    
    ok(snake.pieces, "SnakePieces are created");
    equal(snake.pieces.length, 5, "Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
});

module("Snake.consume");
test("When object is Food, should grow", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
});

test("When object is SnakePiece, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
});

module("Snake.move");
test("The position is changed during move", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.move(1);

    equal(snake.position.x, 140, "Position relative to the X axis changed");
    equal(snake.position.y, 150, "Position relative to the Y axis changed");
});

test("The position of the head is changed during move", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.move(1);

    equal(snake.head.position.x, 140, "Position of the head relative to the X axis changed");
    equal(snake.head.position.y, 150, "Position of the head relative to the Y axis changed");
    deepEqual(snake.position, snake.head.position,"The position of the head determines the position of the snake");
});

test("The position of the inner snake pieces is changed during move", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.move(1);

    equal(snake.pieces[0].position.x, 140, "Position of the head relative to the X axis OK");
    equal(snake.pieces[0].position.y, 150, "Position of the head relative to the Y axis OK");
    equal(snake.pieces[1].position.x, 150, "Position of the first piece relative to the X axis OK");
    equal(snake.pieces[1].position.y, 150, "Position of the first piece relative to the Y axis OK");
    equal(snake.pieces[2].position.x, 160, "Position of the second piece relative to the X axis OK");
    equal(snake.pieces[2].position.y, 150, "Position of the second piece relative to the Y axis OK");
    equal(snake.pieces[3].position.x, 170, "Position of the third piece relative to the X axis OK");
    equal(snake.pieces[3].position.y, 150, "Position of the third piece relative to the Y axis OK");
    equal(snake.pieces[4].position.x, 180, "Position of the fourth piece relative to the X axis OK");
    equal(snake.pieces[4].position.y, 150, "Position of the fourth piece relative to the Y axis OK");
});

module("Snake.changeDirection");

test("The position is changed during direction change", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.changeDirection(1);

    equal(snake.position.x, 150, "Proper rotation relative to the X axis");
    equal(snake.position.y, 140, "Proper rotation relative to the Y axis");
});

test("The position of the head is changed during direction change", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.changeDirection(1);

    equal(snake.head.position.x, 150, "Proper rotation of the head relative to the X axis");
    equal(snake.head.position.y, 140, "Proper rotation of the head relative to the Y axis");
    deepEqual(snake.position, snake.head.position, "The position of the head determines the position of the snake");
});

test("The position of the inner snake pieces is changed during direction change", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.changeDirection(1);

    equal(snake.pieces[0].position.x, 150, "Position of the head relative to the X axis OK");
    equal(snake.pieces[0].position.y, 140, "Position of the head relative to the Y axis OK");
    equal(snake.pieces[1].position.x, 150, "Position of the first piece relative to the X axis OK");
    equal(snake.pieces[1].position.y, 150, "Position of the first piece relative to the Y axis OK");
    equal(snake.pieces[2].position.x, 160, "Position of the second piece relative to the X axis OK");
    equal(snake.pieces[2].position.y, 150, "Position of the second piece relative to the Y axis OK");
    equal(snake.pieces[3].position.x, 170, "Position of the third piece relative to the X axis OK");
    equal(snake.pieces[3].position.y, 150, "Position of the third piece relative to the Y axis OK");
    equal(snake.pieces[4].position.x, 180, "Position of the fourth piece relative to the X axis OK");
    equal(snake.pieces[4].position.y, 150, "Position of the fourth piece relative to the Y axis OK");
});

module("snake.grow");

test("Snake size increases when growing", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    snake.grow();

    equal(snake.size, 6, "The snake size is updated properly");
    equal(snake.pieces.length, snake.size, "The snake pieces are updated properly");
});

module("snake.die");

test("Snake die handler is activated", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);
    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.die();

    ok(isDead, "The snake is dead");
});

test("Many snake die handlers are activated", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    var isDead = false;
    var anotherCheckIsDead = false;
    snake.addDieHandler(function () {
        isDead = true;
    });
    snake.addDieHandler(function () {
        anotherCheckIsDead = true;
    });

    snake.die();

    ok(isDead, "The first handler activates");
    ok(anotherCheckIsDead, "The second handler activates");
});

test("Snake die handler is activated when the snake passes through itself", function () {
    var position = {
        x: 10,
        y: 10
    };
    var speed = 10;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);
    snake.pieces[2].position.x = position.x;
    snake.pieces[2].position.y = position.y;
    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.checkSnakeCollision();

    ok(isDead, "The snake is dead");
});