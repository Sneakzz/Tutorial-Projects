/* Writing to a Stream */
const fs = require('fs');
data = 'Some Random Text';

// Create a writable stream
const writerStream = fs.createWriteStream('output.txt');

// Write the data to the stream with encoding utf8
writerStream.write(data, 'UTF8');

// Mark the end of file
writerStream.end();

// Handle stream events --> finish and error
writerStream.on('finish', () => {
  console.log('Write Complete!');
});

writerStream.on('error', err => {
  console.log(err.stack);
});

console.log('Program Finished');