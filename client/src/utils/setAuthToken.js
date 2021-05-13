import axios from 'axios';

const setAuthToken = (basicToken) => {
  if (basicToken) {
    const { username, password } = JSON.parse(basicToken)
    axios.defaults.headers.common['Authorization'] = "Basic " + btoa(`${username}:${password}`)
  } else {
    delete axios.defaults.headers.auth
  }
};

export default setAuthToken;
