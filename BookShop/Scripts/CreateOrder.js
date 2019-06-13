$(document).ready(function () {
    var productRowsFromLs = JSON.parse(localStorage.getItem("cart"));
    if (productRowsFromLs) {
        var doneCount = 0;
        for (var i = 0; i < productRowsFromLs.length; i++) {
            $.getJSON("/cart/findproduct?productId=" + productRowsFromLs[i].bookId + "&quantity=" + productRowsFromLs[i].quantity, function (product) {
                var newRow = $("<tr>");

                var title = $("<td class='text-left'>" + product.book.Title + "</td>");
                var price = $("<td class='text-left'>" + product.book.Price + "</td>");
                var quantity = $("<td>" + product.qty + "</td>");
                var removeBtn = $("<td><input type='button' id=" + product.book.Id + " class='remove-product btn btn-warning btn-sm' value='Remove'/></td>");
                var rowTotal = $("<td class='sub-total'>" + product.book.Price * product.qty + "</td>");
                newRow.append(title);
                newRow.append(price);
                newRow.append(quantity);
                newRow.append(rowTotal);
                newRow.append(removeBtn);

                $("#cartTable tbody").append(newRow);
            }).done(function () {
                doneCount = doneCount + 1;
                var total = 0;
                if (doneCount === productRowsFromLs.length) {
                    var newRow = $("<tr>");
                    $("#cartTable .sub-total").each(function () {
                        total = total + parseInt($(this).html());
                    });
                    newRow.append($("<td class='total-price text-right'> Total : " + total + "</td>"));
                    $("#cartTable tbody").append(newRow);
                }
            });
        }
    }
    $("#cartTable").on("click", ".remove-product", function () {
        var productRowsFromLs = JSON.parse(localStorage.getItem("cart"));
        if (productRowsFromLs) {
            var bookId = $(this).attr("id");
            productRowsFromLs = productRowsFromLs.filter(function (book) {
                return book.bookId !== bookId;
            });
            localStorage.setItem("cart", JSON.stringify(productRowsFromLs));
        }
        $(this).closest("tr").remove();
        updateTotal();
    });
});

function updateTotal() {

    var total = 0;
    $("#cartTable .sub-total").each(function () {
        total = total + parseInt($(this).html());
    });

    $("#cartTable .total-price").text("Total : "+ total);

}


$(".continue-shopping").on("click", function () {
    location.href = "/Home/Index";
});

$(".checkout-now").on("click", function () {
    $.ajax({
        url: "/Cart/Checkout",
        method: "POST",
        contentType: "application/json;odata=verbose",
        data: localStorage.getItem("cart"),
        success: function (success) { },
        error: function (error) { $(".alert-danger").show(); }

    }).done(function(data) {
        window.location.href = data.newUrl;
    });
});


