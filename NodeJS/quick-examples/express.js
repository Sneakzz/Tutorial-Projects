/* POST Method */

const express = require('express');
const bodyParser = require('body-parser');
const app = express();

// Create application/x-www-form-urlencoded parser
const urlEncodedParser = bodyParser.urlencoded({extended: false});

// serve static files
app.use(express.static('public'));

app.get('/index.html', (req, res) => {
  res.sendFile(__dirname + "/" + "index.html");
});

app.post('/process_post', urlEncodedParser, (req, res) => {
  // Prepare output in JSON format
  response = {
    first_name: req.body.first_name,
    last_name: req.body.last_name
  };

  console.log(response);
  res.end(JSON.stringify(response));
});

const server = app.listen(8081, () => {
  const host = server.address().address;
  const port = server.address().port;

  console.log(`Example app listening at http://${host}:${port}`);
});