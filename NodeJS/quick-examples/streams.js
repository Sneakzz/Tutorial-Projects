/* Piping Streams */

const fs = require('fs');

// Create a readable stream
const readerStream = fs.createReadStream('input.txt');

// Create a writable stream
const writerStream = fs.createWriteStream('output.txt');

// Pipe the read and write operations
// Read input.txt and write data to output.txt
readerStream.pipe(writerStream);

console.log('Program Finished');