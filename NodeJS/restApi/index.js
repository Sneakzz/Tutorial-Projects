const express = require('express');
const bodyParser = require('body-parser');

// Set up express app
const app = express();

app.use(bodyParser.json());

// Initialize routes
app.use('/api', require('./routes/api'));

// Listen for requests
app.listen(process.env.PORT || 4000, () => {
  console.log('Now listening for requests');
});