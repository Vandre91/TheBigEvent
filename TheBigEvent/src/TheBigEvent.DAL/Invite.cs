﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBigEvent.DAL
{
    public class Invite
    {
        public int InviteId { get; set; }
        public int BigSelecteId { get; set; }
        public string Nom { get; set; }
        public string Mail { get; set; }
    }
}
