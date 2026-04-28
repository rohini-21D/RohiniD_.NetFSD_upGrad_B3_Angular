export function formatName(name) {
    return name.toUpperCase();
}
export function calculateAverage(students) {
    //sum =>Accumulator  initial value is  o so we declare 0 last as a initial value
    const total = students.reduce((sum, s) => sum + s.marks, 0);
    return total / students.length;
}
