const express = require('express');
const fs = require('fs');
const app = express();

const user = {
  'user4' : {
    'name' : 'mohit',
    'password' : 'password4',
    'profession' : 'teacher',
    'id' : 4
  }
};

const id = 2;

app.get('/listUsers', (req, res) => {
  fs.readFile(__dirname + '/' + 'users.json', 'utf8', (err, data) => {
    if (err) return console.error(err);

    console.log(data);
    res.end(data);
  });
});

app.post('/addUser', (req, res) => {
  // First read existing users.
  fs.readFile(__dirname + '/' + 'users.json', 'utf8', (err, data) => {
    if (err) return console.error(err);

    data = JSON.parse(data);
    data['user4'] = user['user4'];
    console.log(data);
    res.end(JSON.stringify(data));
  });
});

app.get('/:id', (req, res) => {
  // First read the existing users
  fs.readFile(__dirname + '/' + 'users.json', 'utf8', (err, data) => {
    const users = JSON.parse(data);
    const user = users['user' + req.params.id];
    console.log(user);
    res.end(JSON.stringify(user));
  });
});

app.delete('/deleteUser', (req, res) => {
  // First read the existing users
  fs.readFile(__dirname + '/' + 'users.json', 'utf8', (err, data) => {
    data = JSON.parse(data);
    delete data['user' + id];

    console.log(data);
    res.end(JSON.stringify(data));
  });
});

const server = app.listen(8081, () => {
  const host = server.address().address;
  const port = server.address().port;

  console.log(`Example app listening at http://${host}:${port}`);
});