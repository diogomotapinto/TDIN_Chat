using System;
using System.Collections.Generic;
using MyUser;

namespace Server
{
    class UserServer : MarshalByRefObject, IUsers
    {
        List<User> list;
        public UserServer(List<User> list)
        {
            this.list = list;
        }

        public User find()
        {
            throw new NotImplementedException();
        }

        public List<User> findAll()
        {
            return list;
        }
    }
}
