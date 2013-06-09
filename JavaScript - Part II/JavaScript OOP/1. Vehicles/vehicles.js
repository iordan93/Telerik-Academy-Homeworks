Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
}

// Enumerations
var AfterburnerSwitchState = {
    "Off": 0,
    "On": 1
};
var PropellerDirection = {
    "Clockwise": 1,
    "Counterclockwise": -1
};

var AmphibiousMode = {
    "Land": 0,
    "Water": 1
}

// Base class - propulsion unit
function PropulsionUnit() {
    this.getAcceleration = function () {
        throw new Error("The method getAcceleration is not implemented in the abstract class PropulsionUnit");
    };
}

// Derived classes - wheel, propelling nozzle, and propeller 
function Wheel(radius) {
    this.radius = radius || 0;
    this.getAcceleration = function () {
        return 2 * Math.PI * this.radius;
    }
}
Wheel.inherit(PropulsionUnit);

function PropellingNozzle(power, afterburnerSwitchState) {
    this.power = power || 0;
    this.afterburnerSwitchState = afterburnerSwitchState || AfterburnerSwitchState.Off;
    this.getAcceleration = function () {
        if (this.afterburnerSwitchState === AfterburnerSwitchState.On) {
            return 2 * this.power;
        }
        return this.power;
    }
}
PropellingNozzle.inherit(PropulsionUnit);

function Propeller(numberOfFins, propellerDirection) {
    this.numberOfFins = numberOfFins;
    this.propellerDirection = propellerDirection || PropellerDirection.Clockwise;
    this.getAcceleration = function () {
        return this.propellerDirection * this.numberOfFins;
    }
}
Propeller.inherit(PropulsionUnit);

// Base class - vehicle
function Vehicle(speed, propulsionUnits) {
    this.speed = speed || 0;
    this.propulsionUnits = propulsionUnits || [];
    this.Accelerate = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed = this.speed + this.propulsionUnits[i].getAcceleration();
        }
        return this.speed;
    }
}

// Derived classes - land vehicle, air vehicle, water vehicle, and amphibious vehicle
function LandVehicle(wheelRadius) {
    var numberOfWheels = 4;
    for (var i = 0; i < numberOfWheels; i++) {
        this.propulsionUnits.push(new Wheel(wheelRadius));
    }
}
LandVehicle.inherit(Vehicle);

function AirVehicle(propellingNozzlePower, afterburnerSwitchState) {
    var numberOfPropellingNozzles = 1;
    for (var i = 0; i < numberOfPropellingNozzles; i++) {
        this.propulsionUnits.push(new PropellingNozzle(propellingNozzlePower, afterburnerSwitchState));
    }
    this.ToggleAfterburnerSwitchesState = function () {
        // For each propelling nozzle, toggle its afterburner switch state
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                switch (this.propulsionUnits[i].afterburnerSwitchState) {
                    case AfterburnerSwitchState.On:
                        this.propulsionUnits[i].afterburnerSwitchState = AfterburnerSwitchState.Off;
                        break;
                    case AfterburnerSwitchState.Off:
                        this.propulsionUnits[i].afterburnerSwitchState = AfterburnerSwitchState.On;
                        break;
                    default:
                        throw new Error("Invalid toggle operation on afterburner switch.");
                        break;
                }
            }
        }
    }
}
AirVehicle.inherit(Vehicle);

function WaterVehicle(numberOfPropellers, numberOfFins, propellerDirection) {
    if (numberOfPropellers < 0) {
        throw new Error("The number of propellers must be nonnegative.");
    }
    if (numberOfFins < 0) {
        throw new Error("The number of fins must be nonnegative.");
    }

    for (var i = 0; i < numberOfPropellers; i++) {
        this.propulsionUnits.push(new Propeller(numberOfFins, propellerDirection));
    }
    this.TogglePropellersDirection = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                switch (this.propulsionUnits[i].propellerDirection) {
                    case PropellerDirection.Clockwise:
                        this.propulsionUnits[i].propellerDirection = PropellerDirection.Counterclockwise;
                        break;
                    case PropellerDirection.Counterclockwise:
                        this.propulsionUnits[i].propellerDirection = PropellerDirection.Clockwise;
                        break;
                    default:
                        throw new Error("Invalid toggle operation on propeller.");
                        break;
                }
            }
        }
    }
}
WaterVehicle.inherit(Vehicle);

function AmphibiousVehicle(initialMode, wheelRadius, numberOfPropellers, numberOfFins, propellerDirection) {
    this.mode = initialMode || AmphibiousMode.Land;
    var landMode = new LandVehicle(wheelRadius);
    var waterMode = new WaterVehicle(numberOfPropellers, numberOfFins, propellerDirection);

    this.Accelerate = function () {
        if (this.mode === AmphibiousMode.Land) {
            return landMode.Accelerate();
        }
        else {
            return waterMode.Accelerate();
        }
    }

    this.ChangeMode = function () {
        switch (this.mode) {
            case AmphibiousMode.Land:
                this.mode = AmphibiousMode.Water;
                break;
            case AmphibiousMode.Water:
                this.mode = AmphibiousMode.Land;
                break;
            default:
                throw new Error("Invalid toggle operation on amphibious mode.");
                break;
        }
    }
}
AmphibiousVehicle.inherit(Vehicle);