namespace ShikiApi
{
    public class AbuseRequest : Request
    {
        public AbuseRequestKind Kind { get; set; }
        public bool Value { get; set; }
        public int[] AffectedIds { get; set; }
    }
}