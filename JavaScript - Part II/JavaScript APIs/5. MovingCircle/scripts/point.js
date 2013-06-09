var Point = (function () {
    var Point = function (x, y) {
        this.x = x;
        this.y = y;
    };

    Point.add = function (point1, point2) {
        return new Point(
            point1.x + point2.x,
            point1.y + point2.y
        );
    };

    Point.multiply = function (number, point) {
        return new Point(number * point.x, number * point.y);
    };

    Point.prototype.toString = function () {
        var pointAsString = "x: " + this.x + ", y: " + this.y;

        return pointAsString;
    };

    return Point;
}());