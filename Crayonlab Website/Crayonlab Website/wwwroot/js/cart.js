const cart = {
    items: [],
    get total() {
        return this.items.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    },
    get itemCount() {
        return this.items.reduce((count, item) => count + item.quantity, 0);
    },

    init() {
        this.loadFromLocalStorage();
        this.updateCartUI();
    },

    addItem(product) {
        const existingItemIndex = this.items.findIndex(item => item.id === product.id);
        if (existingItemIndex >= 0) {
            this.items[existingItemIndex].quantity += product.quantity;
        } else {
            this.items.push(product);
        }
        this.saveToLocalStorage();
        this.updateCartUI();
    },

    saveToLocalStorage() {
        localStorage.setItem('shoppingCart', JSON.stringify(this.items));
    },

    loadFromLocalStorage() {
        const savedItems = localStorage.getItem('shoppingCart');
        if (savedItems) {
            this.items = JSON.parse(savedItems);
        }
    },

    updateCartUI() {
        const cartItemsEl = document.getElementById('cartItems');
        const cartTotalEl = document.getElementById('cartTotalPrice');
        const cartCounterEl = document.getElementById('cartCounter');

        if (this.items.length === 0) {
            cartItemsEl.innerHTML = '<div class="empty-cart">Your cart is empty</div>';
        } else {
            cartItemsEl.innerHTML = this.items.map(item => `
                <div class="cart-item">
                    <div>${item.name}</div>
                    <div>₱${(item.price * item.quantity).toFixed(2)}</div>
                    <div>${item.quantity}</div>
                </div>
            `).join('');
        }

        cartTotalEl.textContent = `₱${this.total.toFixed(2)}`;
        cartCounterEl.textContent = this.itemCount;
    }
};

// Initialize the cart when the document is ready
document.addEventListener('DOMContentLoaded', () => {
    cart.init();
});
