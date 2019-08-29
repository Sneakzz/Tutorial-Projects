const express = require('express');
// body-parser module is used so the req.body object can be accessed.
const bodyParser = require('body-parser');
const request = require('request');
const app = express();

const apiKey = '27783d2cd441a3de408803ff6ceccd2d';

// allows access to all static files within the 'public' folder
app.use(express.static('public'));
app.use(bodyParser.urlencoded({extended: true}));
// Change the template engine from the default 'jade' to 'ejs'
app.set('view engine', 'ejs');

app.get('/', (req, res) => {
  res.render('index', {weather: null, error: null});
});

app.post('/', (req, res) => {
  let city = req.body.city;
  let url = `http://api.openweathermap.org/data/2.5/weather?q=${city}&units=metric&appid=${apiKey}`;

  request(url, (err, response, body) => {
    if (err) {
      res.render('index', {weather: null, error: 'Error, please try again'});
    } else {
      let weather = JSON.parse(body);
      if (weather.main == undefined) {
        res.render('index', {weather: null, error: 'Error, please try again'});
      } else {
        let weatherText = `It's ${weather.main.temp} degrees in ${weather.name}!`;
        res.render('index', {weather: weatherText, error: null});
      }
    }
  });
});

app.listen(3000, () => {
  console.log('Example app listening on port 3000!');
});