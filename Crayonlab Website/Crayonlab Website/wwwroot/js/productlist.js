const containerElements = document.querySelectorAll('.CorpoContainer, .BasketballContainer, .SoccerContainer, .SleeveContainer');

containerElements.forEach((container) => {
    const totalSlides = container.children.length;
    let visibleSlides;
    let previousVisibleSlides;

    // Function to set visibleSlides based on screen width
    function setVisibleSlides() {
        if (window.innerWidth <= 768) { // Mobile view
            visibleSlides = totalSlides; // Show all slides
        } else {
            visibleSlides = Math.min(totalSlides, totalSlides-6); // Limit to a maximum of 4 visible slides
        }
    }

    // Set initial visibleSlides
    setVisibleSlides();
    previousVisibleSlides = visibleSlides;

    let currentIndex = 0;

    // Find the existing pagination element
    const pagination = container.parentElement.querySelector('.pagination');

    // Clear existing bullets if any
    pagination.innerHTML = '';

    // Create pagination bullets based on the number of visible slides
    for (let i = 0; i < visibleSlides; i++) {
        const bullet = document.createElement('div');
        bullet.classList.add('pagination-bullet');
        bullet.dataset.index = i;
        bullet.addEventListener('click', () => {
            currentIndex = i; // Set current index to the clicked bullet index
            updateScroll();
            updatePagination();
        });
        pagination.appendChild(bullet);
    }

    function updateScroll() {
        const scrollAmount = currentIndex * (200 + 25); // Width of slide + margin
        container.scrollTo({
            left: scrollAmount,
            behavior: 'smooth'
        });
    }

    function updatePagination() {
        // Remove active class from all bullets in this container
        const bullets = pagination.querySelectorAll('.pagination-bullet');
        bullets.forEach(bullet => bullet.classList.remove('active'));

        // Add active class to the current bullet in this container
        if (bullets[currentIndex]) {
            bullets[currentIndex].classList.add('active');
        }
    }

    function autoScrollLeft() {
        currentIndex++;

        // Reset to the first slide if at the end
        if (currentIndex >= visibleSlides) {
            currentIndex = 0; // Loop back to the start
        }

        updateScroll();
        updatePagination();
    }

    // Set interval for automatic scrolling to the left
    setInterval(autoScrollLeft, 5000); // Change slides every 4 seconds

    // Initialize pagination for the first slide
    updatePagination();

    // Add event listeners for left and right buttons
    const leftButton = container.parentElement.querySelector('.left');
    const rightButton = container.parentElement.querySelector('.right');

    if (leftButton) {
        leftButton.addEventListener('click', () => {
            currentIndex = (currentIndex - 1 + visibleSlides) % visibleSlides; // Decrement index and loop back if necessary
            updateScroll();
            updatePagination();
        });
    }

    if (rightButton) {
        rightButton.addEventListener('click', () => {
            currentIndex = (currentIndex + 1) % visibleSlides; // Increment index and loop back if necessary
            updateScroll();
            updatePagination();
        });
    }

    // Update visibleSlides on window resize
    window.addEventListener('resize', () => {
        setVisibleSlides();
        if (visibleSlides !== previousVisibleSlides) {
            location.reload(); // Reload the browser if visibleSlides value changes
        }
        previousVisibleSlides = visibleSlides;
    });
});

