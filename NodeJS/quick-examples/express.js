/* GET Method */

const express = require('express');
const app = express();

app.use(express.static('public'));

app.get('/index.html', (req, res) => {
  res.sendFile(__dirname + "/" + "index.html");
});

app.get('/process_get', (req, res) => {
  // Prepare output in JSON format
  response = {
    first_name: req.query.first_name,
    last_name: req.query.last_name
  };

  console.log(response);
  res.end(JSON.stringify(response));
});

const server = app.listen(8081, () => {
  const host = server.address().address;
  const port = server.address().port;

  console.log(`Example app listening at http://${host}:${port}`);
});