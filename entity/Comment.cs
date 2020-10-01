using System;
using System.Collections.Generic;

namespace entity
{
    public class  Comment 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}