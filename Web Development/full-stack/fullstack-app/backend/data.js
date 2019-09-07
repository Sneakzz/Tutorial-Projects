const mongoose = require('mongoose');
const Schema = mongoose.Schema;

// This is the structure of the data
const DataSchema = new Schema(
  {
    id: Number,
    message: String
  },
  { timestamps: true }
);

// Create a model from the Schema
const DataModel = mongoose.model('Data', DataSchema);

// Export the model so we can modify it using NodeJS
module.exports = DataModel;