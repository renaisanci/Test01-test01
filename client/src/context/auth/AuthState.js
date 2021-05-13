import React, { useReducer } from 'react';
import axios from 'axios';
import AuthContext from './authContext';
import authReducer from './authReducer';
import setAuthToken from '../../utils/setAuthToken';
import {

  USER_LOADED,
  AUTH_ERROR,
  LOGIN_SUCCESS,
  LOGIN_FAIL,
  LOGOUT,
  CLEAR_ERRORS
} from '../types';


const AuthState = props => {
  const initialState = {
    basicToken: localStorage.getItem('basicToken'),
    isAuthenticated: null,
    loading: true,
    user: null,
    error: null
  };


  const [state, dispatch] = useReducer(authReducer, initialState);

  // Load User
  const loadUser = async () => {
    setAuthToken(localStorage.basicToken);

    try {
      const res = await axios.get(`${process.env.REACT_APP_API_URL}api/Auth`);

      dispatch({
        type: USER_LOADED,
        payload: res.data
      });
    } catch (err) {
      dispatch({ type: AUTH_ERROR });
    }
  };

  // Login User
  const login = async formData => {
    const config = {
      headers: {
        'Content-Type': 'application/json'
      }
    };

    try {
        await axios.post(`${process.env.REACT_APP_API_URL}api/Auth/signin`, formData, config);

      dispatch({
        type: LOGIN_SUCCESS
   
      });

      localStorage.setItem('basicToken', JSON.stringify(formData));
      loadUser();
  
    } catch (err) {
      dispatch({
        type: LOGIN_FAIL,
        payload: err.response?.status
      });
    }
  };

  // Logout
  const logout = () => dispatch({ type: LOGOUT });

  // Clear Errors
  const clearErrors = () => dispatch({ type: CLEAR_ERRORS });

  return (
    <AuthContext.Provider
      value={{
        basicToken: state.basicToken,
        isAuthenticated: state.isAuthenticated,
        loading: state.loading,
        user: state.username,
        error: state.error,
        loadUser,
        login,
        logout,
        clearErrors
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthState;
