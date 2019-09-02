const express = require('express');

// Set up express app
const app = express();

// Listen for requests
app.listen(process.env.PORT || 4000, () => {
  console.log('Now listening for requests');
});