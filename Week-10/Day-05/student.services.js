import { PASS_MARKS } from "./constants";
export function getGrade(marks) {
    if (marks >= 90)
        return "A+";
    else if (marks >= 75)
        return "A+";
    else if (marks >= 60)
        return "B";
    else if (marks >= PASS_MARKS)
        return "C";
    else
        return "Fail";
}
export function getTopper(students) {
    return students.reduce((topper, current) => current.marks > topper.marks ? current : topper);
}
