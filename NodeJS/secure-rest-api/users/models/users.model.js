const mongoose = require('mongoose');

// Use mongoose to connect to a mongoDB instance
mongoose.connect('mongodb://localhost/secure-rest-api', { useNewUrlParser: true });

const Schema = mongoose.Schema;

// Create the users schema
const userSchema = new Schema({
  firstName: String,
  lastName: String,
  email: String,
  password: String,
  permissionLevel: Number
});

const userModel = mongoose.model('Users', userSchema);
