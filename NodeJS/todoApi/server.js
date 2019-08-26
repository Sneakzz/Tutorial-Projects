const express = require('express');
const mongoose = require('mongoose');
const Task = require('./api/models/todoModel') // created model loading here
const bodyParser = require('body-parser');
// Importing route
const routes = require('./api/routes/todoRoutes');

const app = express();
const port = process.env.PORT || 3000;

// mongoose intance connection url
mongoose.Promise = global.Promise;
mongoose.connect('mongodb://localhost/Tododb', { useNewUrlParser: true });

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

// register the routes
routes(app)

app.listen(port);

console.log('todo RESTful API server started on: ' + port);

app.use((req, res) => {
  res.status(404).send({ url: req.originalUrl + ' not found' });
})