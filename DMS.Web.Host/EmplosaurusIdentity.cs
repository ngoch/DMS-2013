using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DMS.Web.Host
{
    public class DMSIdentity : FormsIdentity
    {
        public const char UserDataSeparator = '|';

        //TODO:
        int? _userId;
        public int UserId
        {
            get
            {
                if (!(_userId.HasValue))
                {
                    _userId = Int32.Parse(Ticket.UserData.Split(UserDataSeparator)[0]);
                }
                return _userId.Value;
            }
        }

        string _realName;
        public string RealName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_realName))
                {
                    _realName = Ticket.UserData.Split(UserDataSeparator)[1];
                }
                return _realName;
            }
        }

        public DMSIdentity(FormsAuthenticationTicket ticket)
            : base(ticket)
        { }
    }
}