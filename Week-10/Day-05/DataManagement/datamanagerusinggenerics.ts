function getFirstElement<T>(items:T[]):T{
    return items[0];
}

// Generic interface

interface Repository<T>{
    add(item:T):void;
    getAll():T[];
} 

//Generic Clsss
class DataManager<T> implements Repository<T>{

    private items:T[]=[];

    add(item: T): void {
        this.items.push(item);
    }

    getAll(): T[] {
        return this.items;
    }
}

//Case implementation i.e models
interface User{
    id:number;
    name:string;
}

interface Product{
    id:number;
    title:string;
}

//user DataManaager <T> to store user
const userManager=new DataManager<User>();
userManager.add({id:1,name:"Rohini"});
userManager.add({id:2,name:"Rekha"});

const prodManager=new DataManager<Product>();
prodManager.add({id:101,title:"Laptop"});
prodManager.add({id:102,title:"Mobile"});

//testing
console.log("USers : " , userManager.getAll());
console.log("Products : ", prodManager.getAll());


//genereic function tsting
console.log("First user : " ,getFirstElement(userManager.getAll()));
console.log("First product : ", getFirstElement(prodManager.getAll()));











