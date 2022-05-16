import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';

const MostRecent = () => {
    const history = useHistory();
   
  
    useEffect(() => {
           
        const getLastPostId = async () => {
            const { data } = await axios.get('/api/postcomment/getlastpost');            
            history.push(`/viewblog/${data}`);
                           
        }
        getLastPostId();             
    }, [])
   
    return (
      <h1>Loading...</h1>
              )
}
export default MostRecent;