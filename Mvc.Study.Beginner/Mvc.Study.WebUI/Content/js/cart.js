$(function() {
    loadCart();

    $('.x-product')
        .click(function() {
            var self = $(this);
            addCartItem(self.data('productid'));
            return false;
        });
});

function showCart(data) {
    var template = _.template(
            $("script.x-tp-cart-summary").html()
        );
    $('.x-cart').html(template(data));
}

function loadCart() {
    $.ajax({
        url: $('.x-cart').data('url-cart-summary'),
        data: {},
        type: "GET",
        cache: false,
        success: function (data) {
            showCart(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            
        }
    });
}

function addCartItem(productId) {
    $.ajax({
        url: $('.x-cart').data('url-cart-add'),
        data: {
            productId: productId
        },
        type: "GET",
        cache: false,
        success: function (data) {
            showCart(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    });
}