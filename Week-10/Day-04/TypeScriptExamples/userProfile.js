"use strict";
// 1.	Variable Declaration: 
const userName = "Scott";
let age = 25;
const email = "scott@gmail.com";
const isSubscribed = true;
//Type Interface
let city = "Chennai";
let number = 9876543210;
// operator
age += 1;
// console.log(age);
const userProfileMessage = `Hello ${userName} , You are ${age} years old and your email is ${email}. You Live in ${city} and Your number is ${number}`;
//check eligibility for premium plan
const isEligiblePremium = age > 18 && isSubscribed;
console.log("------User Profile------");
console.log(userProfileMessage);
console.log("Subscribed : ", isSubscribed);
console.log("Eligible For Premium : ", isEligiblePremium);
