using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursiveCommentReplyDemo.Model;

namespace RecursiveCommentReplyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentMasterController : ControllerBase
    {
        [HttpGet]
        [Route("getall-commentReply")]
        public async Task<IActionResult> GetAllCommentReply()
        {
            List<Comment> mainResult = new();
            List<Comment> subtList = new();
            List<Comment> commentList = new();
            List<Comment> allList = new();

            //Get all comment : Means parentId is null
            commentList = Comment.GetAllCommentReply().Where(x => x.ParentId == null).ToList();

            foreach (var item in commentList)
            {
                allList = Comment.GetAllCommentReply().ToList();

                subtList = commentList.Where(x => x.CommentId == item.CommentId).Select(x => new Comment()
                {
                    CommentId = x.CommentId,
                    CommentReply = x.CommentReply,
                    ParentId = x.ParentId,
                    ReplyList = GetAllReplies(ref allList, x.CommentId)
                }
                    ).ToList();
                mainResult.AddRange(subtList);
            }
            return StatusCode(200, mainResult);
        }
        public static List<Comment> GetAllReplies(ref List<Comment> comments, long parentId)
        {
            List<Comment> innerCategories = comments;
            return comments.Where(x => x.ParentId == parentId).Select(m => new Comment()
            {
                CommentId = m.CommentId,
                CommentReply = m.CommentReply,
                ParentId = parentId,
                ReplyList = innerCategories.Where(x => x.ParentId == m.CommentId).Count() > 0 ? GetAllReplies(ref innerCategories, m.CommentId) : null
            }).ToList();

        }

    }
}
