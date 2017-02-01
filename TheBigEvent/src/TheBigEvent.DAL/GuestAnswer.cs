using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class GuestAnswer
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }

    public class Answer
    {
        public DateTime Date { get; set; }
        public AnswerState State { get; set; }
    }

    public enum AnswerState
    {
        None = 0,
        Refused = 1,
        Accepted = 2
    }
}
