$(function() {
    initCart();
});

function initCart() {

    var template = $("script.x-tp-cart-summary").html();
    var compiledTemplate = _.template(template);

    function showCart(data) {
        var cartHtml = compiledTemplate(data);
        $('.x-cart').html(cartHtml);
    }

    function loadCart() {
        $.ajax({
            url: $('.x-cart').data('url-cart-summary'),
            type: "GET",
            cache: false,
            success: showCart
        });
    }

    function addCartItem() {
        var self = $(this);

        $.ajax({
            url: self.data('url-cart-add'),
            type: "GET",
            cache: false,
            success: showCart
        });

        return false;
    }

    $('.x-product').click(addCartItem);

    loadCart();
}