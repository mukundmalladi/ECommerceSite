

function CallToController(a) {

    var DataToGet = a.selectedIndex;

    $.ajax({
        type: 'GET',
        url: '/Products/GetById',
        data: { productId: DataToGet },
        cache: true, //Check this
        success: function(response) {
            var result = response;
            $('#detailsDiv').html(result);

        }

    });
};

function AddToCart(a, b) {

    var productId = a;

    $.ajax({
        type: 'POST',
        url: '/Products/AddToCart',
        data: { productId: productId, quantity: b },
        cache: true, //Check this
        success: function (response) {
            var result = response;
            var data = result.Data;
            if (data.Success ==  true) {
            }
        }
       

    });
};
