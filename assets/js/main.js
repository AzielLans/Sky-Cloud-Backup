const nav_side_bar = document.querySelector("#nav-side-bar");
const nav_scrim = document.querySelector("#nav-scrim");
const active_page = window.location.pathname;
const nav_links = document.querySelectorAll(".nav-links");
const wrapper_body = document.querySelectorAll("#wrapper");
const toc = document.querySelectorAll("#toc");
const BackToTop = document.querySelector("#back-to-top");
const body = document.querySelector("body");
const modeToggle = document.querySelector(".nav-theme-toggle");
const modeToggle_text = document.querySelector("#mode_text");
const modeToggle_icon = document.querySelector("#nav-theme-toggle-icon");
const codeBlocks = document.querySelectorAll("td.rouge-code ");
const copyCodeButtons = document.querySelectorAll("#code-copy-btn");
let codetable = document.querySelectorAll("table.rouge-table");
let value = window.innerWidth;
let darkMode = localStorage.getItem("darkMode");

document.querySelector("#top-bar-checkbtn").onclick = function () {
  new Animation("site-animations-show", "site-animations-hide");
  nav_scrim.style.display = "block";
  disableScroll();
};
document.querySelector("#nav-side-bar-closebtn").onclick = function () {
  new Animation("site-animations-hide", "site-animations-show");
  nav_scrim.style.display = "none";
  enableScroll();
  setTimeout(() => {
    nav_side_bar.classList.remove("site-animations-hide");
  }, 60);
};
nav_scrim.onclick = function () {
  new Animation("site-animations-hide", "site-animations-show");
  nav_scrim.style.display = "none";
  enableScroll();
  setTimeout(() => {
    nav_side_bar.classList.remove("site-animations-hide");
  }, 60);
};
class Animation {
  constructor(add, remove) {
    nav_side_bar.classList.remove(remove);
    nav_side_bar.classList.add(add);
  }
}

function disableScroll() {
  // Get the current page scroll position
  scrollTop = window.pageYOffset || document.documentElement.scrollTop;
  (scrollLeft = window.pageXOffset || document.documentElement.scrollLeft),
    // if any scroll is attempted,
    // set this to the previous value
    (window.onscroll = function () {
      window.scrollTo(scrollLeft, scrollTop);
    });
}

function enableScroll() {
  window.onscroll = function () {};
}

nav_links.forEach((link) => {
  link.classList.remove("nav-links-active");
  if (link.href.includes(`${active_page}`)) {
    link.classList.add("nav-links-active");
  } else {
    if (window.location.pathname.includes("/Post/")) {
      if (link.href.includes("Post")) {
        link.classList.add("nav-links-active");
      }
    }
  }
});
function checkvalue() {
  if (value == 90) {
    nav_scrim.style.display = "none";
    enableScroll();
  }
}
window.addEventListener("DOMContentLoaded", () => {
  const observer = new IntersectionObserver((entries) => {
    if (document.querySelector("#toc")) {
      entries.forEach((entry) => {
        const id = entry.target.getAttribute("id");
        if (entry.isIntersecting === true) {
          document.querySelector(`main li a[href="#${id}"]`).parentElement.classList.add("active");
          document
            .querySelector(`main li a[href="#${id}"]`)
            .parentElement.classList.remove("decative");
        } else {
          document
            .querySelector(`main li a[href="#${id}"]`)
            .parentElement.classList.remove("active");
          document
            .querySelector(`main li a[href="#${id}"]`)
            .parentElement.classList.add("decative");
        }
      });
    }
  });

  // Track all sections that have an `id` applied
  document.querySelectorAll("h1[id], h2[id], h3[id]").forEach((h1, h2, h3) => {
    observer.observe(h1, h2, h3);
  });
});

window.addEventListener("scroll", scrollFunction);

function scrollFunction() {
  if (document.querySelector("#back-to-top")) {
    if (window.pageYOffset > 200) {
      // Show BackToTop
      if (!BackToTop.classList.contains("BTT-Entrance")) {
        BackToTop.classList.remove("BTT-Exit");
        BackToTop.classList.add("BTT-Entrance");
        BackToTop.style.display = "flex";
      }
    } else {
      // Hide BackToTop
      if (BackToTop.classList.contains("BTT-Entrance")) {
        BackToTop.classList.remove("BTT-Entrance");
        BackToTop.classList.add("BTT-Exit");
        setTimeout(function () {
          BackToTop.style.display = "none";
        }, 250);
      }
    }
  }
}
if (document.querySelector("#back-to-top")) {
  BackToTop.addEventListener("click", smoothScrollBackToTop);
}

function smoothScrollBackToTop() {
  window.scrollTo(0, 0);
}

function easeInOutCubic(t, b, c, d) {
  t /= d / 2;
  if (t < 1) return (c / 2) * t * t * t + b;
  t -= 2;
  return (c / 2) * (t * t * t + 2) + b;
}

const enableDarkMode = () => {
  // 1. Add the class to the body
  document.body.classList.add("dark");
  // 2. Update darkMode in localStorage
  localStorage.setItem("darkMode", "enabled");
  modeToggle_icon.textContent = "light_mode";
  modeToggle_text.textContent = "Switch to light Mode";
  modeToggle.classList.add("active");
};

const disableDarkMode = () => {
  // 1. Remove the class from the body
  document.body.classList.remove("dark");
  modeToggle.classList.remove("active");
  modeToggle_icon.textContent = "dark_mode";
  modeToggle_text.textContent = "Switch to dark Mode";
  // 2. Update darkMode in localStorage
  localStorage.setItem("darkMode", null);
};

// If the user already visited and enabled darkMode
// start things off with it on
if (darkMode === "enabled") {
  enableDarkMode();
}

modeToggle.addEventListener("click", () => {
  // get their darkMode setting
  darkMode = localStorage.getItem("darkMode");

  // if it not current enabled, enable it
  if (darkMode !== "enabled") {
    enableDarkMode();
    // if it has been enabled, turn it off
  } else {
    disableDarkMode();
  }
});

// copyCodeButtons.forEach((copyCodeButton, index) => {
//   const code = codeBlocks[index].innerText;

//   copyCodeButton.addEventListener("click", () => {
//     // Copy the code to the user's clipboard
//     window.navigator.clipboard.writeText(code);

//     // Update the button text visually
//     const { innerText: originalText } = copyCodeButton;
//     copyCodeButton.innerText = "content_paste";

//     // After 2 seconds, reset the button to its initial UI
//     setTimeout(() => {
//       copyCodeButton.innerText = originalText;
//     }, 2000);
//   });
// });

codeBlocks.forEach(function (codeBlock) {
  var copyButton = document.createElement('div');
  copyButton.className = 'code-header';
  copyButton.ariaLabel = 'Copy code to clipboard';
  copyButton.id = 'code-header';

  var copyButton_link = document.createElement('span');
  copyButton_link.className = 'material-symbols-rounded';
  copyButton_link.innerText = 'content_copy';

  copyButton.append(copyButton_link);

  codeBlock.append(copyButton);

  copyButton.addEventListener('click', function () {
    let wordToRemove = "$"; 
    var code = codeBlock.querySelector('pre').innerText.replace(wordToRemove, '');
    window.navigator.clipboard.writeText(code);

    copyButton_link.innerText = 'content_paste';
    var fourSeconds = 4000;

    setTimeout(function () {
      copyButton_link.innerText = 'content_copy';
    }, fourSeconds);
  });
});
