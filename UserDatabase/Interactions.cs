using System.Collections.Generic;
using Shared;

namespace UserDatabase
{
    interface Interactions
    {
        bool register(User user);

        bool login(User user);

        bool logout(User user);

        List<User> getOnline();
    }
}
