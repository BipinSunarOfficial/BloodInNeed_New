document.addEventListener("DOMContentLoaded", () => {
    const sidebar = document.querySelector(".sidebar");
    const toggler = document.querySelector(".navbar-toggler");

    // Toggle the sidebar menu on and off for mobile
    if (toggler && sidebar) {
        toggler.addEventListener("click", () => {
            sidebar.classList.toggle("show"); // This will show/hide the sidebar
        });       
    }

    // Handle submenu toggle in sidebar (for dropdowns)
    //const navDropdownToggles = document.querySelectorAll(".nav-link.dropdown-toggle");
    //navDropdownToggles.forEach((dropdownToggle) => {
    //    dropdownToggle.addEventListener("click", (event) => {
    //        event.preventDefault();
    //        const submenu = dropdownToggle.nextElementSibling; // Get the related submenu
    //        if (submenu && submenu.classList.contains('collapse')) {
    //            submenu.classList.toggle("show"); // Toggle visibility of submenu
    //        }
    //    });
    //});

    //// Close all dropdowns when clicking outside the sidebar
    //document.addEventListener("click", (event) => {
    //    const isDropdown = event.target.closest(".collapse");
    //    const isSidebar = event.target.closest(".sidebar");

    //    if (!isSidebar && !isDropdown) {
    //        const allDropdowns = document.querySelectorAll(".collapse.show");
    //        allDropdowns.forEach((dropdown) => {
    //            dropdown.classList.remove("show"); // Hide all dropdowns when clicking outside
    //        });
    //    }
    //});


});
