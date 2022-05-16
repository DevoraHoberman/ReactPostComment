using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactBlogSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBlogSite.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        private string _connectionString;

        public PostCommentController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [Route("getall")]
        [HttpGet]
        public List<Post> GetAll()
        {
            var repo = new PostCommentRepo(_connectionString);
            return repo.GetPosts();
        }

        [Route("addpost")]
        [HttpPost]
        public void AddPost(Post post)
        {
            var repo = new PostCommentRepo(_connectionString);
            post.DateCreated = DateTime.Now;
            repo.AddPost(post);
        }

        [Route("addcomment")]
        [HttpPost]
        public void AddComment(Comment comment)
        {
            var repo = new PostCommentRepo(_connectionString);
            comment.DateCreated = DateTime.Now;
            repo.AddComment(comment);
        }

        [Route("getpostbyid")]
        [HttpGet]
        public Post GetPostById(int id)
        {
            var repo = new PostCommentRepo(_connectionString);
            return repo.GetPostById(id);
        }

        [Route("getcommentsbyid")]
        [HttpGet]
        public List<Comment> GetCommentsById(int id)
        {
            var repo = new PostCommentRepo(_connectionString);
            return repo.GetCommentsById(id);
        }

        [Route("getlastpost")]
        [HttpGet]
        public int GetLastPost()
        {
            var repo = new PostCommentRepo(_connectionString);
            int postId = repo.GetLastPost();
            return postId;
        }


    }
}
