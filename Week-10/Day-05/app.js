import { getGrade, getTopper } from "./student.services";
import { formatName, calculateAverage } from "./utils";
//sample data
const Students = [
    { id: 1, name: "Rohini", marks: 85 },
    { id: 2, name: "arjun", marks: 92 },
    { id: 3, name: "meena", marks: 67 },
    { id: 4, name: "kiran", marks: 45 },
    { id: 5, name: "Reka", marks: 30 }
];
console.log("Formatted names : ");
Students.forEach(s => {
    console.log(formatName(s.name));
});
//Grades
console.log("\n Grades : ");
Students.forEach(s => console.log(`${formatName(s.name)} : ${getGrade(s.marks)}`));
//average
console.log(calculateAverage(Students));
//topepr
console.log(getTopper(Students));
