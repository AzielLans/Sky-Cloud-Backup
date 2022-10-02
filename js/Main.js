const nav = document.getElementById("nav")
const navcheck = document.getElementById("check")
const screenWidth = window.innerWidth;
window.addEventListener("resize", function () {
    if (window.innerWidth !== screenWidth) {
        // Do something
        if (screenWidth < 1993) {
            document.getElementById("banner-content").style.transform = "translateX(0)";
        }
    }
}
);
navcheck.addEventListener('click', () => {
    if (navcheck.checked) {
    nav.style.position = "fixed";
    document.documentElement.style.overflow = "hidden";
    } else {
    nav.style.position = "static";
    document.documentElement.style.overflow = "auto";
    }
});