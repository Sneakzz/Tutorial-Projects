/* child_process module */

// The spawn() method
// launches a new process with given command.
const fs = require('fs');
const child_process = require('child_process');

for(let i = 0; i < 3; i++) {
  const workerProcess = child_process.spawn('node', ['scaling/support.js', i]);

  workerProcess.stdout.on('data', data => {
    console.log(`stdout: ${data}`);
  });

  workerProcess.stderr.on('data', data => {
    console.log(`stderr: ${data}`);
  });

  workerProcess.on('close', code => {
    console.log(`Child process exited with exit code ${code}`);
  });
}