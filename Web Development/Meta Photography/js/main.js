const setup = () => {
  smoothScroll();
}

/* Smoothscrolling */
const smoothScroll = () => {
  let viewBtn = document.querySelector('#view-work');

  viewBtn.addEventListener('click', e => {
    let images = document.querySelector('#images');

    e.preventDefault();

    images.scrollIntoView({
      behavior: 'smooth',
      block: 'start'
    });
    
  });
}

window.addEventListener('load', setup);