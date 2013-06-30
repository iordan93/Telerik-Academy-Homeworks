var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },

    toString: function () {
        var output = "Name: " + this.name + "; Town: " + this.town + "; Classes: ";
        for (var i = 0; i < this.classes.length; i++) {
            output += this.classes[i].className + ", "
        }

        // Trim the last comma
        return output.substr(0, output.length - 2);
    }
}

var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    toString: function () {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        // Call the base constructor and methods first, like in C#
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },

    toString: function () {
        return this._super.toString() + ", Grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (firstName, lastName, age, speciality) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },

    toString: function () {
        return this._super.toString() + ", Speciality: " + this.speciality;
    }
});

var Klass = {
    init: function (courseName, capacity, students, formTeacher) {
        this.className = courseName;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    },

    toString: function () {
        var output = "Name: " + this.className + ", Capacity: " + this.capacity + ", Students: ";
        for (var i = 0; i < this.students.length; i++) {
            output += this.students[i].toString() + ", ";
        }
        output += "Form teacher: " + this.formTeacher.toString();
        return output;
    }
};