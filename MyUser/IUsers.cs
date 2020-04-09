using System;
using System.Collections.Generic;
using System.Text;

namespace MyUser
{
    public interface IUsers
    {
        User find();
        List<User> findAll();

    }
}
