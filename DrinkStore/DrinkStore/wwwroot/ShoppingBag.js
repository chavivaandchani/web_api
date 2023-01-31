window.addEventListener("load", getCart);

function getCart(cart) {
    let cartS = sessionStorage.getItem('cart');
    if (cartS) {
        cartS = JSON.parse(cartS);
        showCart(cartS);
        totalTopayment(cartS);
    }
}

function showCart(cart) {
    for (let i = 0; i < cart.length; i++) {
        let template = document.getElementsByTagName("template");
        let clon = template.content.cloneNode(true);
        clon.querySelector(".itemName").innerText = cart[i].Name;
        clon.querySelector(".image").style.backgroundImage = `url(./image/${product.imgUrl}`;
        clon.querySelector(".price").innerText = String(product.price);
        document.body.appendChild(clon);
    }
}
function totalTopayment(cart){
    let sum = 0, i = 0;
    for (; i < cart.length; i++) {
        sum += cart[i].price;
    }
    document.getElementById("itemCount").innerHTML = i;
    document.getElementById("totalAmount").innerHTML = sum;
}