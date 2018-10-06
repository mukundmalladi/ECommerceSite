
$(document).ready(function() {

    $("#addressDiv").hide();
    $("#submitButton").hide();
});

function validateForm() {

    if (!confirm("Confirm you want to checkout")) {
        return;
    } 
    var addressLine1 = document.forms["CheckoutForm"]["addressLine1"].value;
    var addressLine2 = document.forms["CheckoutForm"]["addressLine2"].value;
    var poBox = document.forms["CheckoutForm"]["poBox"].value;
    var apartmentNo = document.forms["CheckoutForm"]["apartmentNo"].value;
    var houseNo = document.forms["CheckoutForm"]["houseNo"].value;
    var state = document.forms["CheckoutForm"]["state"].value;
    var creditCard = document.forms["CheckoutForm"]["creditCardInfo"].value;
    var zipCode = document.forms["CheckoutForm"]["zipCode"].value;
    

    var productsData = [];
    $(".productData").each(function(rowIndex, r) {
        var data = {};
        var id = $(this)[0].children.productId.textContent.trim();
        var productName = $(this)[0].children.productName.textContent.trim();
        var quantityTr = $(this)[0].children.quantity;
        var quantity = $(quantityTr).find("select").val().trim();
        data.ProductData = { Id: id, ProductName: productName };
        data.Quantity = quantity;
        productsData.push(data);
    });
        $.ajax({
            type: 'POST',
            url: '/Checkout/Checkout',
            data: {
                ProductsData: productsData, ZipCode: zipCode, PoBox: poBox,
                HouseNo: houseNo, ApartmentNo: apartmentNo, AddressLine1: addressLine1,
                AddressLine2: addressLine2, State: state
            },
           //Check this
            success: function (data) {
                alert(data.success);
                window.location = data.response;
            }
            //error: functio

        });
        //$(this).find("td").each(function(colIndex, c) {
        //    col.push(c.textContent);
        //});
        //dataElementsData.push(col);
        // });
        //$(".productData").find(".saveElement"), function (item) {
        //    var dataItem = { Id: parseInt($(item).data("dataelementid")) };
        //    dataItem.Value = $(item).prop("tagName").toLowerCase() == "label" ? $(item).text() : $(item).val();
        //    dataElementsData.push(dataItem);
        //});
        // var 
   //     a = document.forms["CheckoutForm"][" "].value;
   
}

function UpdatePrice(a) {
    var newQuantity = a.value;
    var totalPrice = $("#totalPrice");
    var parent = $(a).parent();
    var nextSibling = parent[0].nextElementSibling;
    var price = nextSibling.textContent.trim();
    var parsePrice = parseFloat(price);
    var textContent = totalPrice[0].textContent.replace(/[^0-9.-]+/g, "");
    var parsedTotalPrice = parseFloat(textContent.trim());

    if (parsePrice !== NaN && parsedTotalPrice !== NaN) {
        var newPrice = parsePrice * newQuantity;
        var parentAgain = $(nextSibling).parent();
        var find = parentAgain.find("#calculatedPrice");

        find[0].innerHTML = newPrice.toFixed(2);
       
    }
    else {
        alert("Invalid data entered");
    }
    var totalCalculatedPrice = 0;
    $(".price").each(function (rowIndex, r) {
        var value = parseFloat(r.textContent);
        totalCalculatedPrice = totalCalculatedPrice + value;
    });
    (totalPrice)[0].innerHTML = "$" + (totalCalculatedPrice).toFixed(2);
}


function ShowOtherStory() {
    $("#addressDiv").show();
    $("#submitButton").show();
    $("#Checkout").hide();
}