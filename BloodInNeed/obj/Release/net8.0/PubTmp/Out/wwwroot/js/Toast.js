// Function to show the toast notifications
function showToast(message, type) {
    // Check if the toast container exists, if not, create it
    let toastContainer = document.querySelector('.toast-container');
    if (!toastContainer) {
        toastContainer = document.createElement('div');
        toastContainer.className = 'toast-container';
        document.body.appendChild(toastContainer);
    }

    // Create a new toast element
    const toast = document.createElement('div');
    toast.className = `toast ${type === 'success' ? 'toast-success' : 'toast-error'}`;
    toast.textContent = message;

    // Append the toast to the container
    toastContainer.appendChild(toast);

    // Display the toast
    setTimeout(() => {
        toast.style.display = 'block';
        toast.style.opacity = 1;
    }, 100);

    // Automatically hide and remove the toast after 3 seconds
    setTimeout(() => {
        toast.style.opacity = 0;
        setTimeout(() => {
            toast.remove();
        }, 500); // Wait for fade-out animation
    }, 3000);
}



// Function to show the loading spinner
function showProcessing() {
    // Check if the loader container exists, if not, create it
    let loaderContainer = document.querySelector('.loader-container');
    if (!loaderContainer) {
        loaderContainer = document.createElement('div');
        loaderContainer.className = 'loader-container';

        // Create the spinner element
        const loader = document.createElement('div');
        loader.className = 'loader';
        loaderContainer.appendChild(loader);

        // Append the loader container to the body
        document.body.appendChild(loaderContainer);
    }

    // Show the loader
    loaderContainer.style.display = 'block';
}

// Function to hide the loading spinner
function hideProcessing() {
    const loaderContainer = document.querySelector('.loader-container');
    if (loaderContainer) {
        loaderContainer.style.display = 'none'; // Hide the loader
    }
}
