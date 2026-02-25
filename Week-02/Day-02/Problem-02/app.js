import { products,calculateTotal } from "./totalCalculate.js";

const totalAmount=calculateTotal(products);


let Invoice=document.getElementById("invoice");

Invoice.innerHTML=` <h3 style="text-decoration:underline;">Shopping Cart Invoice</h3>
<p><strong> Products :</strong>${products .map(p=>`${p.name}  - ₹${p.price} x ${p.quantity}` ) 
    .join("<br>")} </p>

    Total Amount : ₹${totalAmount}`;

    console.log(invoice);