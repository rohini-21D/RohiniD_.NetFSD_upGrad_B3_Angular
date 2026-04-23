// 1.	Variable Declaration: 
const userName:string="Scott";
let age:number=25;
const email:string="scott@gmail.com";
const isSubscribed:boolean=true;

//Type Interface

let city="Chennai";
let number=9876543210;

// operator

age+=1;
// console.log(age);

const userProfileMessage:string=`Hello ${userName} , You are ${age} years old and your email is ${email}. You Live in ${city} and Your number is ${number}`;





//check eligibility for premium plan
const isEligiblePremium:boolean= age>18 && isSubscribed;

console.log("------User Profile------");
console.log(userProfileMessage);
console.log("Subscribed : " , isSubscribed);
console.log("Eligible For Premium : " , isEligiblePremium);
