/* child_process module */

// The fork() method
// This is a special case of the spawn method() to create Node processes
const fs = require('fs');
const child_process = require('child_process');

for(let i = 0; i < 3; i++) {
  const workerProcess = child_process.fork('scaling/support.js', [i]);

  workerProcess.on('close', code => {
    console.log(`Child process exited with code ${code}`);
  });
}