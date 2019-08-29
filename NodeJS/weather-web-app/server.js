const express = require('express');
app.set('view engine', 'ejs');
const app = express();

app.get('/', (req, res) => {
  res.render('index');
});

app.listen(3000, () => {
  console.log('Example app listening on port 3000!');
});