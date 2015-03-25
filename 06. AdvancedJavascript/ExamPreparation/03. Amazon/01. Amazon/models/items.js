var models = models || {};

(function(scope) {
    function Item(title, description, price) {
        this.title = title;
        this.description = description;
        this.price = price;
        this._customerReviews = [];
    }

    Item.prototype.addCustomerReview = function(customerReview) {
        this._customerReviews.push(customerReview);
    }

    Item.prototype.getCustomerReviews = function() {
        return this._customerReviews;
    }
    
    Object.prototype.inherits = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }
    
    var condition = {
        veryGood: 'Very good',
        likeNew: 'Like new',
        good: 'Good',
        acceptable: 'Acceptable'
    }

    function UsedItem(title, description, price, condition) {
        Item.call(this, title, description, price);
        this.condition = condition;
    }

    UsedItem.inherits(Item);

    scope.getItem = function(title, description, price) {
        return new Item(title, description, price);
    }

    scope.getUsedItem = function (title, description, price, condition) {
        return new UsedItem(title, description, price, condition);
    }
})(models);