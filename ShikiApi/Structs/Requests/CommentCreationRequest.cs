namespace ShikiApi
{
    //TODO: Create
    public class CommentCreationRequest :Request
    {
        public string Body { get; set; }
        public int CommentableId { get; set; }
    }
}