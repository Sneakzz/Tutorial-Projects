/* Remove a directory */

const fs = require('fs');

console.log('Going to delete directory ./tmp/test');

fs.rmdir('./tmp/test', err => {
  if (err) return console.error(err);

  console.log('Going to read directory ./tmp');

  fs.readdir('./tmp/', (err, files) => {
    if (err) return console.error(err);

    files.forEach( file => {
      console.log(file);
    });
  });
});