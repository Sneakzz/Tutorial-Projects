/* Delete a File */

const fs = require('fs');

console.log('Going to delete an existing file');

fs.unlink('input.txt', err => {
  if (err) return console.error(err);

  console.log('File deleted successfully!');
});