// Toggle search bar visibility
const searchToggle = document.getElementById('search-toggle');
const searchBar = document.getElementById('search-bar');

if (searchToggle) {
    searchToggle.addEventListener('click', () => {
        searchBar.style.display = searchBar.style.display === 'block' ? 'none' : 'block';
    });
}

// Hover effect for button
const shopButton = document.getElementById('shop-btn');

if (shopButton) {
    shopButton.addEventListener('mouseover', () => {
        shopButton.style.backgroundColor = '#f0f0f0';
    });

    shopButton.addEventListener('mouseout', () => {
        shopButton.style.backgroundColor = 'white';
    });
}



// for the products.html
document.addEventListener('DOMContentLoaded', () => {
    // Retrieve product info from localStorage
    const productName = localStorage.getItem('productName') || 'Product Name';
    const productImage = localStorage.getItem('productImage') || 'default.jpg';
    const productPrice = localStorage.getItem('productPrice') || '₱600';

    // Assign to DOM
    document.getElementById('productName').textContent = productName;
    document.getElementById('productImage').src = productImage;
    document.getElementById('productPrice').textContent = productPrice;

    // Quantity selector
    const minusBtn = document.getElementById('minusBtn');
    const plusBtn = document.getElementById('plusBtn');
    const quantityInput = document.getElementById('quantityInput');

    minusBtn.addEventListener('click', () => {
        let currentVal = parseInt(quantityInput.value);
        if (currentVal > 1) {
            quantityInput.value = currentVal - 1;
        }
    });

    plusBtn.addEventListener('click', () => {
        let currentVal = parseInt(quantityInput.value);
        quantityInput.value = currentVal + 1;
    });

    // Men/Women toggle logic
    const menBtn = document.getElementById('menBtn');
    const womenBtn = document.getElementById('womenBtn');
    const menSizes = document.getElementById('menSizes');
    const womenSizes = document.getElementById('womenSizes');

    // Initially hide both sets
    menSizes.style.display = 'none';
    womenSizes.style.display = 'none';

    // Helper function to reset active class
    function resetActive() {
        menBtn.classList.remove('active');
        womenBtn.classList.remove('active');
    }

    // Men button click
    menBtn.addEventListener('click', () => {
        resetActive();
        menBtn.classList.add('active');
        menSizes.style.display = 'flex';
        womenSizes.style.display = 'none';
    });

    // Women button click
    womenBtn.addEventListener('click', () => {
        resetActive();
        womenBtn.classList.add('active');
        menSizes.style.display = 'none';
        womenSizes.style.display = 'flex';
    });
});

//for the shop.html

document.querySelectorAll('.product').forEach(product => {
    product.addEventListener('click', function () {
        const name = this.getAttribute('data-name');
        const image = this.getAttribute('data-image');
        const price = this.getAttribute('data-price');
        localStorage.setItem('productName', name);
        localStorage.setItem('productImage', image);
        localStorage.setItem('productPrice', price);
        window.location.href = 'product.html';
    });
});
