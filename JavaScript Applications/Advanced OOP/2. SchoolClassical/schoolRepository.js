var School = Class.create({
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
});

var Person = Class.create({
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    toString: function () {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    }
});

var Student = Class.create({
    init: function (firstName, lastName, age, grade) {
        // Call the base constructor and methods first, like in C#
        this._super = new this._super(firstName, lastName, age);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },

    toString: function () {
        return this._super.toString() + ", Grade: " + this.grade;
    }
});

Student.inherit(Person);

var Teacher = Class.create({
    init: function (firstName, lastName, age, speciality) {
        this._super = new this._super(firstName, lastName, age);
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },

    toString: function () {
        return this._super.toString() + ", Speciality: " + this.speciality;
    }
});

Teacher.inherit(Person);

var Klass = Class.create({
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
});