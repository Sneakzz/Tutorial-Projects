// Import the express node module
const express = require('express');
// Initialize express server and store into app
const app = express();

const port = 3000;

// Define a get request that returns a list of users.
app.get('/url', (req, res, next) => {
  res.json(['Tony', 'Lisa', 'Michael', 'Bob', 'Moula']);
});

// Set the server to listen on port 3000 + create callback function that says the server is running on port 3000.
app.listen(port, () => {
  console.log('Server running on port 3000');
});