using System;

namespace ShikiApi
{
    public class Character
    {                   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Russian { get; set; }
        public Image Image { get; set; }
        public string Url { get; set; }
    }
}