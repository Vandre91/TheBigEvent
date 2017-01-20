using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public string Text { get; set; }
    }
}
