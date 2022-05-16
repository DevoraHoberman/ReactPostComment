import React, { useState, useEffect } from 'react';
import axios from 'axios';
import CommentForm from './CommentForm';
import CommentRows from './CommentRows';
import { useParams, useHistory } from 'react-router-dom';
import format from 'date-fns/format';



const ViewBlog = () => {
    const [post, setPost] = useState([]);
    const history = useHistory();
    const { postId } = useParams();

    useEffect(() => {
        const getPost = async () => {
            const { data } = await axios.get(`/api/postcomment/getpostbyid?id=${postId}`);

            setPost(data);
        }
        getPost();
    }, []);



    return (
        <div className='container mt-5' style={{ minHeight: 100, paddingTop: 10 }}>
            <div className='row mt-5'>
                <div className='col-lg-8'>
                    <h1>{post.title}</h1>
                    <p className='lead'>
                        by {'Commentator'}
                    </p>
                    <hr />
                    <div>
                        <p>Posted on {post.dateCreated}</p>
                    </div>
                    <hr />
                    <p style={{ whiteSpace: 'prewrap' }}>{post.content}</p>
                </div>
            </div>
            <CommentForm postId={post.id} />
            <CommentRows postId={post.id} />
        </div >

    )
}
export default ViewBlog;