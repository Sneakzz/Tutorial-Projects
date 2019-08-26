'use strict'
const mongoose = require('mongoose');
const Task = mongoose.model('Tasks');

exports.listAllTasks = (req, res) => {
  Task.find({}, (err, task) => {
    if(err) {
      res.send(err);
    }
    res.json(task);
  });
};

exports.createTask = (req, res) => {
  const newTask = new Task(req.body);
  newTask.save((err, task) => {
    if(err) {
      res.send(err);
    }
    res.json(task);
  });
};

exports.readTask = (req, res) => {
  Task.findById(req.params.taskId, (err, task) => {
    if(err) {
      res.send(err);
    }
    res.json(task);
  });
};

exports.updateTask = (req, res) => {
  Task.findOneAndUpdate({_id: req.params.taskId}, req.body, {new: true}, (err, task) => {
    if(err) {
      res.send(err);
    }
    res.json(task);
  });
};

exports.deleteTask = (req, res) => {
  Task.remove({
    _id: req.params.taskId
  }, (err, task) => {
    if(err) {
      res.send(err);
    }
    res.json({ message: 'Task successfully deleted' });
  });
};
