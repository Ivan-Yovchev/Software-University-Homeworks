var models = models || {};

(function(scope) {
    function ShoppingCart() {
        this._items = [];
    }

    ShoppingCart.prototype.addItem = function(item) {
        this._items.push(item);
    }

    ShoppingCart.prototype.getTotalPrice = function() {
        var sum = 0;
        for (var item in this._items) {
            sum += item.price;
        }

        return sum;
    }
        
    scope._ShoppingCart = ShoppingCart;    

    scope.getShoppingCart = function() {
        return new ShoppingCart();
    }
})(models)