// Import the fs (filesystem) module
const fs = require('fs');

// Blocking code example
const data = fs.readFileSync('input.txt');

console.log(data.toString());
console.log('Program Finished');


// Non-Blocking code example
fs.readFile('input.txt', (err, data) => {
  if (err) return console.error(err);
  console.log(data.toString());
});

console.log('Program Finished');