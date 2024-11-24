const dropdownToggle = document.querySelector('.dropdown-toggle');
const dropdownMenu = document.querySelector('.dropdown-menu');
const dropdownItems = document.querySelectorAll('.dropdown-item');
const bars = document.querySelector('.fa-bars');
const mobileNavbar = document.querySelector('.mobilenav-container')

dropdownToggle.addEventListener('click', function () {
dropdownMenu.style.display = (dropdownMenu.style.display === 'block') ? 'none' : 'block';
});

dropdownItems.forEach(item => {
item.addEventListener('click', function () {
    dropdownMenu.style.display = (dropdownMenu.style.display === 'block') ? 'none' : 'block';
});
});


const toggleNav = () => {
    if (mobileNavbar.classList == "mobilenav-container") {
        mobileNavbar.classList.remove("mobilenav-container");
        mobileNavbar.classList.add("mobilenav-containeractive");
    } else {
        mobileNavbar.classList.remove("mobilenav-containeractive");
        mobileNavbar.classList.add("mobilenav-container");
    }
}



