document.addEventListener('DOMContentLoaded', function () {
    var searchNavbar = document.querySelector('.search_navbar');
    var searchInputWrap = document.querySelector('.search-input-wrap');

    searchNavbar.addEventListener('click', function (event) {
        if (event.target.classList.contains('search-icon')) {
            searchNavbar.classList.toggle('expanded');
            if (searchNavbar.classList.contains('expanded')) {
                searchInputWrap.querySelector('.search-input').focus();
            }
        }
    });

    document.addEventListener('click', function (event) {
        if (!searchNavbar.contains(event.target)) {
            searchNavbar.classList.remove('expanded');
        }
    });
});
