const express = require('express');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');

// Set up express app
const app = express();

// Connect to mongodb
mongoose.connect('mongodb://localhost/ninjago', { useNewUrlParser: true });
mongoose.Promise = global.Promise;

app.use(bodyParser.json());

// Initialize routes
app.use('/api', require('./routes/api'));

// Listen for requests
app.listen(process.env.PORT || 4000, () => {
  console.log('Now listening for requests');
});