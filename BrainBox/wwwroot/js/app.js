document.addEventListener('DOMContentLoaded', function () {
  const backgrounds = [
      'image/11.jpg',
      'image/12.jpg',
      'image/13.jpg',
      // Add more background image paths as needed
  ];

  let currentBackgroundIndex = 0;
  const backgroundSlideshow = document.createElement('div');
  backgroundSlideshow.classList.add('background-slideshow');
  const homwSection = document.querySelector('.homw');
  homwSection.appendChild(backgroundSlideshow);

  function changeBackground() {
      currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.length;
      backgroundSlideshow.style.backgroundImage = `url(${backgrounds[currentBackgroundIndex]})`;
  }
  // Change background every 10 seconds
  setInterval(changeBackground, 10000);

  // Initial background
  changeBackground();
});




var typed = new Typed(".text", {
  strings: ["shop toys", "buy toys","discover more toys"],
  typeSpeed: 100,
  backSpeed: 100,
  backDelay: 1000,
  loop: true,
});

let section = document.querySelector(".three");
let spans = document.querySelectorAll(".progress span");
window.onscroll = function () {
  if (window.scrollY >= section.offsetTop - 1000) {
    spans.forEach((span) => {
      span.style.width = span.dataset.width;
    });
  }
};


