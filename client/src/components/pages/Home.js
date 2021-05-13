import React from 'react';
 
const onSubmit = e => {
  e.preventDefault();
 
};

const Home = () => {
  return (
    <div className='form-container'>
    <h1>
   <span className='text-primary'>  Matches Game </span>
    </h1>
    <form onSubmit={onSubmit}>
 
      <input
        type='submit'
        value='PLAY NOW >>'
        className='btn btn-primary btn-block'
      />
    </form>
  </div>
  );
};

export default Home;


