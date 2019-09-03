const express = require('express');
const router = express.Router();

// Get list of ninjas from db
router.get('/ninjas', (req, res) => {
  res.send({ type: 'GET'});
});

// Add new ninja to db
router.post('/ninjas', (req, res) => {
  console.log(req.body);
  res.send({ 
    type: 'POST',
    name: req.body.name,
    rank: req.body.rank
  });
});

// Update ninja in db
router.put('/ninjas/:id', (req, res) => {
  res.send({ type: 'PUT'});
});

// Delete ninja from db
router.delete('/ninjas/:id', (req, res) => {
  res.send({ type: 'DELETE'});
});

module.exports = router;