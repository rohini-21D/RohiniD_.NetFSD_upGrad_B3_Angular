export const products = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 },
    { name: "Headphones", price: 2000, quantity: 1 }
];

export const calculateTotal =(items)=>{
     return items 
     .map(item=>item.price *item.quantity) 
     .reduce((total,prod)=>total+prod);
};

       


        
        {/* // arrow function
        // const add=(a,b)=>{
        // return a+b;
        // };
        // console.log(add(5,3)) */}