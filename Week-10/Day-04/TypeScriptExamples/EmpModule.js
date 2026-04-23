"use strict";
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id,
            this.name = name;
        this.salary = salary;
    }
    //get teh salary 
    getSalary() {
        return this.salary;
    }
    //set eith validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    //method for displayin detaisl
    displayDetails() {
        console.log(`ID : ${this.id}`);
        console.log(`Name : ${this.name}`);
        console.log(`Salary : ${this.salary}`);
    }
}
class Manager extends Employee {
    teamSize = 0;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary); //calling here from base consrtuct tht is Employee
        this.teamSize = teamSize;
    }
    //  Method Overriding
    displayDetails() {
        super.displayDetails(); //reus9ng the parent method
        console.log(`Team Size : ${this.teamSize}`);
    }
}
//Object Creation
var emp = new Employee(1, "Scott", 50000);
var mng = new Manager(2, "John", 80000, 5);
console.log("-----Method Calling-----");
emp.displayDetails();
//ex:uoadate salary using setter
emp.setSalary(55000);
console.log("Updated Saalary : ", emp.getSalary());
console.log("\n------Manager Details------");
mng.displayDetails();
