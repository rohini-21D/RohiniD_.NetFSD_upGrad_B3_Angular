$(document).on("click",".add-to-cart",function(){
    // console.log("Button is clicked");

    let id=$(this).data("id");
    // console.log(id);

    let cart = JSON.parse(localStorage.getItem("cart"));

    if(!Array.isArray(cart)){
        cart = [];
    }

    let existing = cart.find(item => item.id == id);

    if(existing){
        existing.qty += 1;
    }else{
        cart.push({id:id, qty:1});
    }

    localStorage.setItem("cart", JSON.stringify(cart));

    alert("Item added to Cart!");
});

function updateCartCount(){
    let cart=JSON.parse(localStorage.getItem("cart")) || [];

    let count=0;

    cart.forEach(item => {
        count+=item.qty;
    });

    $("#cartCount").text(count);
}

$(document).ready(function(){
    updateCartCount();
})