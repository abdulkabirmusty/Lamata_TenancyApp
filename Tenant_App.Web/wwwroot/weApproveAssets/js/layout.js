const dropdownToggle = document.querySelector('.dropdown-toggle');
const dropdownMenu = document.querySelector('.dropdown-menu');
const dropdownItems = document.querySelectorAll('.dropdown-item');

dropdownToggle.addEventListener('click', function () {
dropdownMenu.style.display = (dropdownMenu.style.display === 'block') ? 'none' : 'block';
});

dropdownItems.forEach(item => {
item.addEventListener('click', function () {
    dropdownMenu.style.display = (dropdownMenu.style.display === 'block') ? 'none' : 'block';
});
});