/* Reading from a Stream */

const fs = require('fs');
let data = '';

// Create a readable stream
const readerStream = fs.createReadStream('input.txt');

// Set the encoding to utf8
readerStream.setEncoding('UTF8');

// Handle stream events --> data, end and error
readerStream.on('data', chunk => {
  data += chunk;
});

readerStream.on('end', () => {
  console.log(data);
});

readerStream.on('error', err => {
  console.log(err.stack);
});

console.log('Program Finished');