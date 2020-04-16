using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared
{
    public class Conversation
    {
        User userOne;
        User userTwo;
        public Conversation(User userOne, User userTwo)
        {
            this.userOne = userOne;
            this.userTwo = userTwo;
        }

        public override bool Equals(object obj)
        {
            return obj is Conversation conversation &&
                   EqualityComparer<User>.Default.Equals(userOne, conversation.userOne) &&
                   EqualityComparer<User>.Default.Equals(userTwo, conversation.userTwo) || obj is Conversation conversationOne &&
                   EqualityComparer<User>.Default.Equals(userOne, conversationOne.userTwo) &&
                   EqualityComparer<User>.Default.Equals(userTwo, conversationOne.userOne);
        }
    }
}
