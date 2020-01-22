// When the user scrolls the page, execute myFunction
window.onscroll = function () { myFunction() };

// Get the header
var header = document.getElementById("busqueda-container");
var reemplazo = document.getElementById("reemplazo-header");

// Get the offset position of the navbar
var sticky = header.offsetTop;

// Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
function myFunction() {
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
        reemplazo.classList.add("reemplazo-activo");
        reemplazo.classList.remove("reemplazo");
    } else {
        header.classList.remove("sticky");
        reemplazo.classList.remove("reemplazo-activo");
        reemplazo.classList.add("reemplazo");
    }
}