// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

getCartItemsCount();

function getCartFromLocalStorage() {
    var cartJson = localStorage.getItem('Cart');
    return cartJson ? JSON.parse(cartJson) : [];
}

function saveCartToLocalStorage(cart) {
    var cartJson = JSON.stringify(cart);
    localStorage.setItem('Cart', cartJson);
}

function addToCart(assetId, title, price) {
    var cart = getCartFromLocalStorage();
    
    var existingItem = cart.find(item => item.AssetId === assetId);

    if (!existingItem) {
        cart.push({AssetId: assetId, Title: title, Price: price} );
    }

    saveCartToLocalStorage(cart);
    getCartItemsCount();
}

function removeFromCart(assetId) {
    var cart = getCartFromLocalStorage();

    cart = cart.filter(item => item.AssetId !== assetId);

    saveCartToLocalStorage(cart);
    getCartItemsCount();
    sendCart();
}

function getCartItemsCount() {
    var cart = getCartFromLocalStorage();

    let count = Object.keys(cart).length;

    let e = document.getElementById('cartItemCount');

    if (count > 0) {
        e.classList.add('bg-danger');
    }

    e.textContent = count;
}

async function sendCart() {
    var cartItems = getCartFromLocalStorage();
    var token = document.getElementById("RequestVerificationToken").value;

    $.ajax({
        url: '/Shop/GetCart',
        type: 'POST',
        headers: {
            RequestVerificationToken: token
        },
        contentType: 'application/json',
        data: JSON.stringify(cartItems),
        success: function (response) {
            
            window.location.href = "/Shop/Cart";
        },
        error: function (error) {
            // Handle error response
            console.error('Error sending cart data:', error);
        }
    });
}