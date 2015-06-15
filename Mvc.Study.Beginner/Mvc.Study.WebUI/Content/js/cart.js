$(function() {
    initCart();
});

function initCart() {
    
    var compiledTemplate = _.template($("script.x-tp-cart-summary").html());

    function showCart(data) {
        var cartHtml = compiledTemplate(data);
        $('.x-cart').html(cartHtml);
    }

    function loadCart() {
        $.ajax({
            url: $('.x-cart').data('url-cart-summary'),
            data: {},
            type: "GET",
            cache: false,
            success: showCart
        });
    }

    function addCartItem() {

        var self = $(this);

        $.ajax({
            url: self.data('url-cart-add'),
            data: {},
            type: "GET",
            cache: false,
            success: showCart
        });

        return false;
    }

    $('.x-product').click(addCartItem);

    loadCart();
}