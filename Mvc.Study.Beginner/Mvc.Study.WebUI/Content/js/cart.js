$(function() {
    initCart();
});

function initCart() {

    var loadingTemplate = $("script.x-tp-cart-loading").html();
    var compiledloadingTemplate = _.template(loadingTemplate);

    var template = $("script.x-tp-cart-summary").html();
    var compiledTemplate = _.template(template);

    function showLoading() {
        var loading = compiledloadingTemplate();
        $('.x-cart').html(loading);
    }

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

        showLoading();
    }

    function addCartItem() {
        var self = $(this);

        setTimeout(function() {
            $.ajax({
                url: self.data('url-cart-add'),
                type: "GET",
                cache: false,
                success: showCart
            });
        }, 500);

        showLoading();

        return false;
    }

    $('.x-product').click(addCartItem);

    loadCart();
}