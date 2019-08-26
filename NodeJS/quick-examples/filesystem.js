/* Truncate a File */

const fs = require('fs');
const buf = new Buffer(1024);

console.log('Going to open an existing file');

fs.open('input.txt', 'r+', (err, fd) => {
  if (err) return console.error(err);

  console.log('File opened successfully!');
  console.log('Going to truncate the file after 10 bytes');

  // Truncate the opened file.
  fs.ftruncate(fd, 10, err => {
    if (err) return console.error(err);

    console.log('File truncated successfully');
    console.log('Going to read the same file');

    fs.read(fd, buf, 0, buf.length, 0, (err, bytes) => {
      if (err) return console.error(err);

      // Print only read bytes to avoid junk.
      if (bytes > 0) console.log(buf.slice(0, bytes).toString());

      // Close the opened file
      fs.close(fd, err => {
        if (err) return console.error(err);

        console.log('File closed successfully!');
      });
    });
  });
});