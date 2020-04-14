using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFram
{
    interface Interactions
    {
        bool register(User user);

        bool login(User user);

        bool logout(User user);
    }
}
