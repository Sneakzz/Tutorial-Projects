'use strict'
module.exports = app => {
  const todoList = require('../controllers/todoController');

  // todoList Routes
  app.route('/tasks')
    .get(todoList.listAllTasks)
    .post(todoList.createTask);

  app.route('/tasks/:taskId')
    .get(todoList.readTask)
    .put(todoList.updateTask)
    .delete(todoList.deleteTask);
}