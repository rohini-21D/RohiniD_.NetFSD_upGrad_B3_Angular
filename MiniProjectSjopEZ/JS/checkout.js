$(document).ready(function(){

    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    if(cart.length === 0){
        $("#orderSummary").html("<p>Your cart is empty</p>");
        return;
    }

    $.getJSON("data/products.json", function(products){

        let output = "";
        let total = 0;

        cart.forEach(item => {
            let product = products.find(p => p.id == item.id);

            let subtotal = product.price * item.qty;
            total += subtotal;

            output += `
                <p>${product.name} X ${item.qty} = ₹${subtotal}</p>
            `;
        });

        $("#orderSummary").html(output);
        $("#orderTotal").text(total);
    });
});

// handle form submit
$(document).on("submit", "#checkoutForm", function(e){
    e.preventDefault();

    // hide all checkout content
    $("#checkoutContent").hide();

    // show success message
    $("#successMsg").show();

    // clear cart
    localStorage.removeItem("cart");
    setTimeout(() => {
    window.location.href = "index.html";
}, 3000);
});