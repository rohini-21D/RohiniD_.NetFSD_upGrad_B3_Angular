import { PASS_MARKS } from "./constants";
import { Student } from "./student.models";

export function getGrade(marks:number) : string{
    if(marks>=90) return "A+";
    else if(marks>=75) return "A+";
    else if(marks>=60) return "B";
    else if(marks>=PASS_MARKS) return "C";
    else return "Fail";
}

export function getTopper(students:Student[]):Student{
    return students.reduce((topper,current)=>current.marks>topper.marks ? current : topper);
}