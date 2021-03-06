﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBigEvent.DAL;

namespace TheBigEvent.Services
{
    public class MessageService
    {
        readonly MessageLink _mLink;

        public MessageService(string connectionString)
        {
            _mLink = new MessageLink(connectionString);
        }

        public Result<IEnumerable<Message>> getMessage(int id1,int id2)
        {
            return Result.Success(Status.Ok, _mLink.GetAllMessage(id1,id2));
        }
        public void addMessage( int _UserId1, int _UserId2, string _Text)
        {
            _mLink.AddMessage(_UserId1, _UserId2, _Text);
        }
    }
}
