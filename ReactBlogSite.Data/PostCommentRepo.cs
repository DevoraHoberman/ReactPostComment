using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactBlogSite.Data
{
    public class PostCommentRepo
    {
        private readonly string _connectionString;

        public PostCommentRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Post> GetPosts()
        {
            using var context = new PostCommentDataContext(_connectionString);
            return context.Posts.Include(p => p.Comments).ToList();
        }
        public void AddPost(Post post)
        {
            using var context = new PostCommentDataContext(_connectionString);
            context.Posts.Add(post);
            context.SaveChanges();
        }
        public void AddComment(Comment comment)
        {
            using var context = new PostCommentDataContext(_connectionString);
            context.Comments.Add(comment);
            context.SaveChanges();
        }
        public Post GetPostById(int id)
        {
            using var context = new PostCommentDataContext(_connectionString);
            return context.Posts.Where(p => p.Id == id).Include(p => p.Comments).FirstOrDefault();
        }
        public List<Comment> GetCommentsById (int id)
        {
            using var context = new PostCommentDataContext(_connectionString);
            return context.Comments.Where(c => c.PostId == id).ToList();
        }
        public int GetLastPost()
        {
            using var context = new PostCommentDataContext(_connectionString);
            var id = context.Posts.OrderByDescending(p => p.DateCreated).Select(p => p.Id).FirstOrDefault();
            return id;
        }

    }
}
