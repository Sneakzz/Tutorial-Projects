import React, { Component } from "react";
import axios from 'axios';

class App extends Component {
  // Initialize state
  state = {
    data: [],
    id: 0,
    message: null,
    intervalIsSet: false,
    idToDelete: null,
    idToUpdate: null,
    objectToUpdate: null
  };

  // When component mounts, first thing it does is fetch all existing data in the db.
  // Then create polling logic so it is possible to easily see if the db has changed and implement those changes into the UI.
  componentDidMount() {
    this.getDataFromDb();

    if (!this.state.intervalIsSet) {
      let interval = setInterval(this.getDataFromDb, 1000);
      this.setState({ intervalIsSet: interval });
    }
  };

  // Never let a process live forever
  // Always kill a process everytime it is done being used
  componentWillUnmount() {
    if (this.state.intervalIsSet) {
      clearInterval(this.state.intervalIsSet);
      this.setState({ intervalIsSet: null });
    }
  };

  // A note: here, in the front-end, the id key of our data object is used
  // to identify which we want to Update or Delete.
  // For the back-end, the object id assigned by MongoDB is used to modify
  // database entries.

  // First GET method that uses the backend api to fetch data from the db
  getDataFromDb = () => {
    fetch('http://localhost:3001/api/getData')
      .then(data => data.json())
      .then(res => this.setState({ data: res.data }));
  };

  // POST method that uses the backend api to create new data
  // and store it into the db
  postDataToDb = message => {
    let currentIds = this.state.data.map(data => data.id);
    let idToBeAdded = 0;
    while (currentIds.includes(idToBeAdded)) {
      ++idToBeAdded;
    }

    axios.post('http://localhost:3001/api/putData', {
      id: idToBeAdded,
      message: message
    });
  };

  // DELETE method that uses the backend api to remove existing data
  deleteFromDb = idToDelete => {
    parseInt(idToDelete);
    let objIdToDelete = null;
    this.state.data.forEach(data => {
      if (data.id == idToDelete) {
        objIdToDelete = data._id;
      }
    });

    axios.delete('http://localhost:3001/api/deleteData', {
      data: {
        id: objIdToDelete
      }
    });
  };

  // PUT method that uses the backend api to overwrite existing data
  updateDb = (idToUpdate, updateToApply) => {
    let objIdToUpdate = null;
    parseInt(idToUpdate);
    this.state.data.forEach(data => {
      if (data.id == idToUpdate) {
        objIdToUpdate = data._id;
      }
    });

    axios.put('http://localhost:3001/api/updateData', {
      id: objIdToUpdate,
      update: { message: updateToApply }
    });
  };

  // This is the UI
  render() {
    const { data } = this.state;
    return (
      <div>
        <ul>
          {
            data.length <= 0 ? 'NO DB ENTRIES YET' : data.map(dat => (
              <li style={{ padding: '10px' }} key={data.message}>
                <span style={{ color: 'gray' }}> id: </span> {dat.id}  <br />
                <span style={{ color: 'gray' }}> data: </span> {dat.message}
              </li>
            ))
          }
        </ul>
        <div style={{ padding: '10px' }}>
          <input
            type='text'
            onchange={e => this.setState({ message: e.target.value })}
            placeholder='add something in the database'
            style={{ width: '200px' }}
          />
          <button onClick={() => this.postDataToDb(this.state.message)}>
            ADD
          </button>
        </div>
        <div style={{ padding: '10px' }}>
          <input
            type='text'
            style={{ width: '200px' }}
            onChange={e => this.setState({ idToDelete: e.target.value })}
            placeholder='put id of item to delete here'
          />
          <button onClick={() => this.deleteFromDb(this.state.idToDelete)}>
            DELETE
          </button>
        </div>
        <div style={{ padding: '10px' }}>
          <input
            type='text'
            style={{ width: '200px' }}
            onChange={e => this.setState({ idToUpdate: e.target.value })}
            placeholder='put id of item to update here'
          />
          <input
            type='text'
            style={{ width: '200px' }}
            onChange={e => this.setState({ updateToApply: e.target.value })}
            placeholder='put new value of the item here'
          />
          <button onClick={() => this.updateDb(this.state.idToUpdate, this.state.updateToApply)}>
            UPDATE
          </button>
        </div>
      </div>
    );
  };
}

export default App;