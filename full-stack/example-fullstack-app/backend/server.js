const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');
const bodyParser = require('body-parser');
const logger = require('morgan');
const Data = require('./data');

const API_PORT = 3001;
const app = express();
app.use(cors());
const router = express.Router();

// This is MongoDB database connection string
const dbRoute = 'mongodb+srv://sneakzz:Testing123@cluster0-xgci0.gcp.mongodb.net/test?retryWrites=true&w=majority';

// Connects the back end code with the database
mongoose.connect(dbRoute, { useNewUrlParser: true });

let db = mongoose.connection;

db.once('open', () => console.log('connected to the database'));

// Check if connection with the database is successful
db.on('error', console.error.bind(console, 'MongoDB connection error:'));

// (optional) only made for logging and BodyParser parses the request body
// to be in a readable json format
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
app.use(logger('dev'));

// GET method
// This method fetches all available data in the database
router.get('/getData', (req, res) => {
  Data.find((err, data) => {
    if (err) return res.json({ success: false, error: err });

    return res.json({ success: true, data: data });
  });
});

// POST method
// This method adds new data to the database
router.post('/putData', (req, res) => {
  let data = new Data();

  const { id, message } = req.body;

  if ((!id && id !== 0) || !message) {
    return res.json({
      success: false,
      error: 'INVALID INPUTS'
    });
  }

  data.message = message;
  data.id = id;
  data.save(err => {
    if (err) return res.json({ success: false, error: err });
    return res.json({ success: true });
  });
});

// PUT method
// This method overwrites existing data in our database
router.put('/updateData', (req, res) => {
  const { id, update } = req.body;
  Data.findByIdAndUpdate(id, update, err => {
    if (err) return res.json({ success: false, error: err });

    return res.json({ success: true });
  });
});

// DELETE method
// This method removes existing data from the database
router.delete('/deleteData', (req, res) => {
  const { id } = req.body;
  Data.findByIdAndRemove(id, err => {
    if (err) return res.json({ success: false, error: err });

    return res.json({ success: true });
  });
});

// append /api for the http requests
app.use('/api', router);

// launch backend into a port
app.listen(API_PORT, () => console.log(`Listening on port ${API_PORT}`));