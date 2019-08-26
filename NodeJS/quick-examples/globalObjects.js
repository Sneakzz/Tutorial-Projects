// __filename
console.log(__filename);

// __dirname
console.log(__dirname);

// setTimeout(cb, ms)
const printHello = () => {
  console.log('Hello, World!');
}

// Call above function after 2 seconds
setTimeout(printHello, 2000);

// clearTimeout(t)
// Call above function after 2 seconds
const t = setTimeout(printHello, 2000);

// Clear the timer
clearTimeout(t);

// setInterval(cb, ms)
setInterval(printHello, 2000);