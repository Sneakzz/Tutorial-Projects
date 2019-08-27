/* Basic routing */

const express = require('express');
const app = express();

// This responds with 'Hello GET' on the homepage
app.get('/', (req, res) => {
  console.log('Got a GET request for the homepage');
  res.send('Hello GET');
});

// This responds to a POST request for the homepage
app.post('/', (req, res) => {
  console.log('Got a POST request for the homepage');
  res.send('Hello POST');
});

// This responds to a DELETE request for the /del_user page.
app.delete('/del_user', (req, res) => {
  console.log('Got a DELETE request for /del_user');
  res.send('Hello DELETE');
});

// This responds to a GET request for the /list_user page.
app.get('/list_user', (req, res) => {
  console.log('Got a GET request for /list_user');
  res.send('Page Listing');
});

// This responds to a GET request for abcd, abxcd, ab123cd, and so on
app.get('/ab*cd', (req, res) => {
  console.log('Got a GET request for /ab*cd');
  res.send('Page Pattern Match');
});

const server = app.listen(8081, () => {
  const host = server.address().address;
  const port = server.address().port;

  console.log(`Example app listening at http://${host}:${port}`);
})