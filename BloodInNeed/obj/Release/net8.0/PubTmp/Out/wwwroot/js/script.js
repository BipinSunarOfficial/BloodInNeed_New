document.addEventListener("DOMContentLoaded", () => {
    const sidebar = document.querySelector(".sidebar");
    const toggler = document.querySelector(".navbar-toggler");

    // Toggle the sidebar menu on and off for mobile
    if (toggler && sidebar) {
        toggler.addEventListener("click", () => {
            sidebar.classList.toggle("show"); // This will show/hide the sidebar
        });       
    }

    document.addEventListener('mouseover', (event) => {
        // Check if the hovered element is an option inside a select
        if (event.target.tagName === 'OPTION') {
            event.target.classList.add('hovered-option');
        }
    });

    document.addEventListener('mouseout', (event) => {
        // Remove hover effect when the mouse leaves the option
        if (event.target.tagName === 'OPTION') {
            event.target.classList.remove('hovered-option');
        }
    });


});
