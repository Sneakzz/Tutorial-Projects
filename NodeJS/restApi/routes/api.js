const express = require('express');
const router = express.Router();
const Ninja = require('../models/ninja');

// Get list of ninjas from db
router.get('/ninjas', (req, res) => {
  res.send({ type: 'GET' });
});

// Add new ninja to db
router.post('/ninjas', (req, res) => {
  Ninja.create(req.body).then(ninja => {
    res.send(ninja);
  });
});

// Update ninja in db
router.put('/ninjas/:id', (req, res) => {
  res.send({ type: 'PUT' });
});

// Delete ninja from db
router.delete('/ninjas/:id', (req, res) => {
  res.send({ type: 'DELETE' });
});

module.exports = router;