
async function login() {
    const userName = document.getElementById("userNameSignIn").value;
    const password = document.getElementById("passwordSignIn").value;
    const response = await fetch(`https://localhost:44335/api/user/?userName=${userName}&password=${password}`);
    if (!response.ok) {
        throw Error(`Error: you have some problem in status ${response.status}, try again later`)
    }
    else if (response.status == 204) {
        alert("oops,user not found");
        return;
    }

    else {
        const res = await response.json();
        sessionStorage.setItem('user', JSON.stringify(res));
        user = JSON.parse(sessionStorage.getItem('user'));
        alert(`hello ${user.firstName}, we hope you will enjoy`);
        placeOrder();  
    }
}
async function update() {
    window.location.href = "userDetails.html";
}

function getUserFromHtml(userName, password, firstName, lastName) {
    UserName = document.getElementById(userName).value;
    Password = document.getElementById(password).value;
    FirstName = document.getElementById(firstName).value;
    LastName = document.getElementById(lastName).value;
    return { "userName": UserName, "password": Password, "firstName": FirstName, "lastName": LastName };
}

function showLogin() {
    const f = document.getElementById("login");
    f.style.visibility = "visible";
   // alert("in login")
}

async function enrollToSite() {
    user = getUserFromHtml("userName", "fName", "lName", "password");
    const response = await fetch("https://localhost:44335/api/user", {
        headers: { "Content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(user)
    });
    if (response.ok)
        alert("yey!! we happy you chose using our site");
    else {
        alert("ooooppss something wrong, please try again later");
    }

}

async function updateDetails() {
    let user = await getUpdatedDetails();
    const response = await fetch(`https://localhost:44335/api/user/${user.userId}`, {
        headers: { "Content-Type": "application/json;charset=utf-8" },
        method: 'PUT',
        body: JSON.stringify(user)
    });
    if (response.ok) {
        user = JSON.parse(sessionStorage.getItem('user'));
        alert(`${user.firstName} your details updated successfuly`);
    }

}

function ShowUserDetailsAfterUpdating() {
    const f = document.getElementById("updateDetails");
    f.style.visibility = "visible";

    const passwordAfterUpdating = document.getElementById("passwordD");
    const fNameAfterUpdating = document.getElementById("fNameD");
    const lNameAfterUpdating = document.getElementById("lNameD");
    const userNameAfterUpdating = document.getElementById("userNameD");

    const user = JSON.parse(sessionStorage.getItem('user'));

    userNameAfterUpdating.setAttribute("value", user.userName);
    passwordAfterUpdating.setAttribute("value", user.password);
    fNameAfterUpdating.setAttribute("value", user.firstName);
    lNameAfterUpdating.setAttribute("value", user.lastName);
}

function getUpdatedDetails() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    const id = user.userId;
    userAfterUpdate = getUserFromHtml("userNameD", "passwordD", "fNameD", "lNameD");
    userAfterUpdate.userId = id;
    sessionStorage.setItem('user', JSON.stringify(userAfterUpdate));
    console.log(userAfterUpdate);
    return userAfterUpdate;
}

async function checkPassword() {
    const password = document.getElementById("password").value;
    const response = await fetch("https://localhost:44335/api/password", {
        headers: { "Content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(password)
    });
    console.log(response);
    if (response.ok) {
        const res = await response.json();
        alert(res);
    }
    else {
        alert("ooooppss");
    }
}
async function placeOrder() {
    order = await newOrder();
    console.log(order)
    const neworder = await fetch(`https://localhost:44335/api/Order`, {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(order)
    });
       alert("Your order status is: "+neworder.ok);
    return neworder.ok;
}
function newOrder() {
    
        let myCart = getfromSession();
        /*    let mySum = document.getElementById("totalAmount").innerHTML;*/
        let mySum=sessionStorage.getItem('sum');
        let productIds = [];
        for (var i = 0; i < myCart.length; i++) {
            let amount = 0;
            for (var i2 = 0; i2 < myCart.length; i2++) {
                if (myCart[i].productId == myCart[i2].productId) {
                    amount = amount + 1;
                }
            }
            orderItem = { "ProductId": myCart[i].productId, "Quantity": amount };
            productIds.push(orderItem);
        }

        order = { "OrderDate": new Date(), "OrderSum": mySum, "UserId": 1, "OrderItem": productIds }
        return order;
    
}
function getfromSession() {
    const myCart = sessionStorage.getItem('basket');
    return JSON.parse(myCart);
}


