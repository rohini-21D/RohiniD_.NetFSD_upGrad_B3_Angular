$(document).ready(function(){

    // adding to cart

    let cart=JSON.parse(localStorage.getItem("cart")) || [];

    if(cart.length===0){
        $("#checkoutBtn").addClass("disabled");
        $("checkoutBtn").attr("href","#");
       
    }

    $.getJSON("data/products.json",function(products){
        let output="";
        let total=0;

        cart.forEach(item => {

            let product=products.find(p=>p.id==item.id);

            let subtotal=product.price*item.qty;

            total+=subtotal;

            output+=`
            <div class="card p-2 mb-2">
                <h5>${product.name}</h5>
                <p>Price: ₹${product.price}</p>
                <div>
                    <button class="btn btn-secondary decrease" data-id="${product.id}"> - </button>
                    <span class="mx-2">${item.qty}</span>
                    <button class="btn btn-secondary increase" data-id="${product.id}"> + </button>
                </div>
                <p> Subtotal : ₹${subtotal}</p>
            </div>
            `
        });

        $("#cartItems").html(output);
        $("#cartTotal").text(total);
    })

    // iiincrease from acrt
    $(document).on("click",".increase",function(){
        let id=$(this).data("id");

        let cart=JSON.parse(localStorage.getItem("cart")) || [];

        let item=cart.find(p=>p.id==id);

        if(item){
            item.qty+=1;
        }

        localStorage.setItem("cart",JSON.stringify(cart));
        location.reload();
    })

    // decreasing from cart

    $(document).on("click",".decrease",function(){
        let id=$(this).data("id");
        // console.log(id);

        let cart=JSON.parse(localStorage.getItem("cart")) ||[];

        let item=cart.find(item=>item.id==id);

        if(item){
            item.qty-=1;

            if(item.qty<=0){
                cart=cart.filter(p=>p.id!=id);
            }
        }
        localStorage.setItem("cart",JSON.stringify(cart));

        location.reload();
    })
})