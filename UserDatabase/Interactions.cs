using System.Collections.Generic;
using Shared;

namespace UserDatabase
{
    interface Interactions
    {
        bool register(User user);

        bool login(User user);

        bool logout(User user);

        void findUser(string name);

        void setState(string name, bool state);


        List<User> getOnline();
    }
}
