namespace RecursiveCommentReplyDemo.Model
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string CommentReply { get; set; }
        public long? ParentId { get; set; }
        public List<Comment> ReplyList { get; set; }
        public static List<Comment> GetAllCommentReply()
        {
            return new List<Comment>()
            {
                new Comment(){CommentId=1,CommentReply="First Comment1",ParentId=null},
                new Comment(){CommentId=2,CommentReply="Second Comment",ParentId=null},
                new Comment(){CommentId=3,CommentReply="Third Comment1",ParentId=null},

                 new Comment(){CommentId=4,CommentReply="Comment1.1",ParentId=1},
                 new Comment(){CommentId=5,CommentReply="Second Comment1.1.2",ParentId=4},
                 new Comment(){CommentId=6,CommentReply="Third Comment1.1.2.3",ParentId=5},

                 new Comment(){CommentId=7,CommentReply="Second Comment2.1",ParentId=2},
                 new Comment(){CommentId=8,CommentReply="Second Comment2.2",ParentId=2},
                 new Comment(){CommentId=9,CommentReply="Third Comment3.1",ParentId=3},

                 new Comment(){CommentId=10,CommentReply="First Comment2.2",ParentId=7},
                 new Comment(){CommentId=11,CommentReply="Second Comment2.3",ParentId=10},
                 new Comment(){CommentId=12,CommentReply="Third Comment2.4",ParentId=10},
            };
        }
    }
}
