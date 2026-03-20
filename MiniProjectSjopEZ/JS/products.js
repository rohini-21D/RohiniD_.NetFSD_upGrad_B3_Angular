$(document).ready(function () {

    // displaying 3 products on home page
    if($("#featuredProducts").length){
        
        $.getJSON("data/products.json", function (products) {
            
            let output = "";
            
            let features=products.slice(0,3);
            
            features.forEach(product => {
                
                output += `
                <div class="col-12 col-sm-6 col-md-4 col-l-3">
                <div class="card h-100">
                
                <img src="${product.image[0]}" class="card-img-top" style="height:200px;object-fit:cover;">
                
                <div class="card-body text-center">
                <h5>${product.name}</h5>
                <p>₹${product.price}</p>
                
                <a href="product-details.html?id=${product.id}" class="btn btn-primary">View</a>
                <button class="btn btn-success add-to-cart" data-id="${product.id}">Add to Cart</button>
                </div>
                
                </div>
                </div>
                `;
            });
            
            $("#featuredProducts").html(output);
            
        });
    }

    // all products in peoducts page
    if($("#allProducts").length){
        $.getJSON("data/products.json",function(products){
            let params=new URLSearchParams(window.location.search);
            let category=params.get("category");
            
            if(category){
                products=products.filter(p=>p.category===category);
            }

            let output="";
            products.forEach(product=>{             
                output+=`
                        <div class="col-12 col-sm-6 col-md-4 col-lg-3">
                            <div class="card h-100 shadow-sm">
                                <img src="${product.image[0]}" class="card-img-top" style="height:200px; object-fit:cover;">

                                <div class="card-body text-center">
                                    <h5>${product.name}</h5>
                                    <p>₹${product.price}</p>

                                    <a href="product-details.html?id=${product.id}" class="btn btn-primary">View</a>

                                    <button class="btn btn-success add-to-cart" data-id="${product.id}">Add to Cart</button>
                                </div>

                            </div>
                        </div>`;
            })
            $("#allProducts").html(output);
        });
    }
    
    // when we clickon view the will exceute
    if($("#productDetails").length){
        let params=new URLSearchParams(window.location.search);
        // console.log(params);
        let productId=params.get("id");
        // console.log(productId);

        $.getJSON("data/products.json",function(products){
            let product= products.find(p=>p.id==productId);

            // seting big image automatically by default
            $("#bigImg").attr("src",product.image[0]);

            // craeting small images

            let smallImgs="";
            product.image.forEach(img=>{
                smallImgs+=`
                <img src="${img}" class="smImg m-1" >
                `
            })
            $("#smallImages").html(smallImgs);

            let info=`
             <h2>${product.name}</h2>
                <p>${product.description}</p>
                <h3>₹${product.price}</h3>

                <button class="btn btn-success add-to-cart" data-id="${product.id}">Add to Cart</button>
            `
            $("#productInfo").html(info);

            // mouseover efect when we moveober imgae it will show the small images
            $(".smImg").mouseover(function(){
                let str=$(this).attr("src");
                $("#bigImg").attr("src",str);
            })
        })
    }

    
});