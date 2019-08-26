/* Writing a file */

const fs = require('fs');

console.log('Going to write into existing file');

fs.writeFile('input.txt', 'Some Random Text', err => {
  if (err) return console.error(err);

  console.log('Data written successfully!');
  console.log("Let's read newly written data");

  fs.readFile('input.txt', (err, data) => {
    if (err) return console.error(err);

    console.log('Asynchronous read: ' + data.toString());
  });
});