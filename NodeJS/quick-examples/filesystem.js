/* Read a directory */

const fs = require('fs');

console.log('Going to read directory /tmp');

fs.readdir('./tmp/', (err, files) => {
  if (err) return console.error(err);

  files.forEach( file => {
    console.log(file);
  });
});