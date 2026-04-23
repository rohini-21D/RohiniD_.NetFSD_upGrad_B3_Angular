//Function with Required paramas

function getWelcomeMessage(name:string):string{
    return `Welcome ${name} ! `;
}

//Optional Parameter

function getUserInfo(name:string,age?:number):string{
    if(age!==undefined){
        return `User:${name}, Age : ${age}`;
    }

    return `User: ${name}`;
}

//Default Parameters
function getSubscription(name:string,isSubscribed:boolean=false):string{
    return isSubscribed ? `${name} is subscibed` : `${name} is not subscribed`;
}

//Return Types
function isEligibleForPremium(age:number):boolean{
    return age>18;
}

//Arrow Functions
const getGreeting=(name:string):string=> { return `Hello ${name}!`;}

//Lexical this
var NotificationService={
    appName:"MyApp",
    sendNotification:(user:string):string=>{
        return `Notification from ${NotificationService.appName} to ${user}`;
    }
}



console.log("-------Function Outputs-------");

console.log("Function with Required paramas")
console.log(getWelcomeMessage("Scott"));

console.log("----------------------------------")

console.log("Optional Parameter");
console.log(getUserInfo("Rohini",21));

console.log("----------------------------------")

console.log("Default Parameter");
console.log(getSubscription("Rohini",true));
console.log(getSubscription("John"));

console.log("----------------------------------")

console.log("Return Types");
console.log("Rligible for Premimum ",isEligibleForPremium(20));

console.log("----------------------------------")

console.log("Arrow Functions");
console.log(getGreeting("Davis"));

console.log("----------------------------------")

console.log("Lexical This");
console.log(NotificationService.sendNotification("Scott"));