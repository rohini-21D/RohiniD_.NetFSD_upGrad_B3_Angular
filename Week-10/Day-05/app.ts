import { Student } from "./student.models";
import { getGrade,getTopper } from "./student.services";
import { formatName,calculateAverage } from "./utils";

//sample data
const students:Student[]=[
    { id: 1, name: "Rohini", marks: 85},
    { id: 2, name: "arjun", marks: 92},
    { id: 3, name: "meena", marks: 67 },
    { id: 4, name: "kiran", marks: 45 },
    { id: 5, name: "Reka", marks: 30 }
];

console.log("Formatted names : ");

students.forEach(s=>{
    console.log(formatName(s.name));
});

//Grades
console.log("\n Grades : ");
students.forEach(s => {
  console.log(`${formatName(s.name)}: ${getGrade(s.marks)}`);
});
//average

console.log(calculateAverage(students));

//topepr
const topper=getTopper(students);
console.log("\nTopper",formatName(topper.name));