using HipchatApiV2.Responses;

namespace HipChatWPF.Model
{
    public class User
    {
        private readonly HipchatUser _user;

        public User(HipchatUser user)
        {
            _user = user;
        }

        public override string ToString()
        {
            return _user.Name ;
        }
    }
}
