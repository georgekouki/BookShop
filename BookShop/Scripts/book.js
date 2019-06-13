
$(document).ready(function () {
    var productList = [];


    //Detta körs när sidan laddats

    $(".add-to-cart").on("click", function () {
        var ls = JSON.parse(localStorage.getItem("cart"));
        if (ls !== null) {
            productList = ls;
        }
        var id = $(this).attr("id");
        var amount = 1;
        var found = false;
        for (var i = 0; i < productList.length; i++) {
            if (productList[i].bookId === id) {
                productList[i].quantity += amount;
                found = true;
                break;
            }
        }
        if (!found) {
            productList.push({ bookId: id, quantity: amount });
        }
        try {
            localStorage.setItem("cart", JSON.stringify(productList));

        } catch (e) {
            alert("Somthing went wrong.. please try again!");
        }
        alert("The item is added to cart");

    });

    $(".checkout").on("click", function () {
        location.href = "/cart/createorder";
      

    });
});