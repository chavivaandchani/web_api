window.addEventListener("load", GetProduct());
window.addEventListener("load", GetCategory());


async function GetProduct() {
    const res = await fetch(`https://localhost:44338/api/Products`)
    const res1 = await res.json();
    ShowProduct(res1); 
    return res1;
}
function ShowProduct(products) {
    products.forEach(product => ShowProducts(product))
}
function ShowProducts(product) {
    var price = String(product.price);
    var tmp = document.getElementById("temp-card");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector("h1").innerText = product.name;
    clon.querySelector(".price").innerText = price;
    clon.querySelector(".description").innerText = product.description;
    clon.querySelector("img").src = "./images/" + product.imageUrl;
    clon.querySelector(".btn").addEventListener('click', () => {addToCart(product) });

    document.body.appendChild(clon);

}
async function GetCategory() {
    const res = await fetch(`https://localhost:44338/api/Categorys`);
    const res1 = await res.json();
    console.log(res1)
    ShowCategory(res1)

}
function ShowCategory(Category) {
    Category.forEach(category => ShowCategorys(category))
}

function ShowCategorys(category) {
    var tmp = document.getElementById("temp-category");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector(".opt").id = category.id;
    clon.querySelector(".opt").value = category.id;
    clon.querySelector(".OptionName").innerText = category.name;
    clon.querySelector(".opt").addEventListener('click', filterProducts);
    document.getElementById("categoryList").appendChild(clon);
}

//function sortByCategory() {
//  var products = GetProduct();
//    console.log("okoa", products);
//   var categories = [];
//    var categories = document.getElementsByClassName("nameFilter filterBreak").value;
//    categories.filter(cat => {
//        console.log(cat)
//        if (cat.value == true)
//            products = products.forEach(pro => 
//                pro.ProductCategoryId === categories.categoryId
//            )
//   })
//    ShowProducts(products);
//}

async function removeProduct() {

    const res = document.getElementsByClassName("card");
    for (let i = res.length - 1; i >= 0; i--) {
        var prod = res[i]
        document.body.removeChild(prod);
    }
    const res1 = document.getElementsByClassName("card");
    console.log(res1, "huyus");
}

async function filterProducts() {

    var categoryIds = ``;
    var categoryList = document.getElementsByClassName("opt");
    console.log(categoryList, "huhuh");
    for (var i = 0; i < categoryList.length; i++) {
        console.log(categoryList[i])
        if (categoryList[i].checked) {
            categoryIds += `&categoryIds=${categoryList[i].id}`;

        }
        var name = document.getElementById("nameSearch").value;

        var minPrice = document.getElementById("minPrice").value;
        var maxPrice = document.getElementById("maxPrice").value;

        let queryString = ``;
        name != null ? queryString += `&name=${name}` : queryString += ``;
        if (categoryIds != null) {
            queryString += categoryIds;
        }
        else {
            queryString += ``;
        }
        minPrice != null ? queryString += `&minPrice=${minPrice}` : queryString += ``;
        maxPrice != null ? queryString += `&maxPrice=${maxPrice}` : queryString += ``;



        console.log(queryString);
        const res = await fetch(`api/Products/?${queryString}`);

        const product = await res.json();
        console.log(product);
        removeProduct();
        ShowProduct(product)

    }


}
function addToCart(product) {
    let cartS = sessionStorage.getItem('cart');
    cart = JSON.parse(cartS);
    if (cart == null)
        cart = [];
    cart.push(product);
    document.getElementById('ItemsCountText').innerText = cart.length;
    sessionStorage.setItem('cart', JSON.stringify(cart))
    console.log(cart);
}
