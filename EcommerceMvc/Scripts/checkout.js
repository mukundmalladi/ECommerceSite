
$(document).ready(function() {

    $("#addressDiv").hide();
    $("#submitButton").hide();
});

function validateForm() {
    
        var addressLine1 = document.forms["CheckoutForm"]["inputAddress"].value;
        var addressLine2 = document.forms["CheckoutForm"]["inputAddress2"].value;
        var city = document.forms["CheckoutForm"]["city"].value;
        var zipCode = document.forms["CheckoutForm"]["inputZip"].value;
        var state = document.forms["CheckoutForm"]["inputState"].value;
        var sameAddress = document.forms["CheckoutForm"]["same-address"].value;
        var saveInfo = document.forms["CheckoutForm"]["save-info"].value;
        var credit = document.forms["CheckoutForm"]["credit"].value;//
        var creditCardName = document.forms["CheckoutForm"]["cc-name"].value;
        var creditCardNumber = document.forms["CheckoutForm"]["cc-number"].value;//
        var creditCardExpiration = document.forms["CheckoutForm"]["cc-expiration"].value;
        var creditCardCvv = document.forms["CheckoutForm"]["cc-cvv"].value;

    var productsData = [];
    $(".productData").each(function(rowIndex, r) {
        var data = {};
        var id = $(this).find("#productId")[0].textContent.trim();
        var productName = $(this).find("#productName")[0].textContent.trim();
        var quantity = $(this).find("#quantity")[0].value.trim();
        data.ProductData = { Id: id, ProductName: productName };
        data.Quantity = quantity;
        productsData.push(data);
    });
        $.ajax({
            type: 'POST',
            url: '/Checkout/Checkout',
            data: {
                ProductsData: productsData, ZipCode: zipCode, City: city,
                SameAddress: sameAddress === "on", SaveInfo: saveInfo === "on", AddressLine1: addressLine1,
                AddressLine2: addressLine2, State: state, CreditCard: credit, CreditCardName: creditCardName, CreditCardNumber: creditCardNumber,
                CreditCardExpiration: creditCardExpiration, CreditCardCvv: creditCardCvv
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

function UpdatePrice(selector) {
    var newQuantity = selector.value;
    var totalPrice = $("#totalPrice");
    var parent = $(selector);
    var nextSibling = parent[0].nextElementSibling;
    var price = nextSibling.textContent.trim();
    var parsePrice = parseFloat(price);
    var textContent = totalPrice[0].textContent.replace(/[^0-9.-]+/g, "");
    var parsedTotalPrice = parseFloat(textContent.trim());

    if (!isNaN(parsePrice) && !isNaN(parsedTotalPrice)) {
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
    (totalPrice)[0].innerHTML = "$" + totalCalculatedPrice.toFixed(2);
}


function ShowOtherStory() {
    $("#addressDiv").show();
    $("#submitButton").show();
    $("#Checkout").hide();
}


function HideAddressFormFields(value) {
    $(".form-row ").each(function (rowIndex, r) {
        r.style.display = "none";
    }); 
    $(".form-row ").find("input").each(function (rowIndex, r) {
        r.required = false;
    }); 

}