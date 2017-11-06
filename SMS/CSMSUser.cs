using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS
{
    public class CSMSUser
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string School { get; set; }

        public string ParentUserId { get; set; }

        public bool IsPrimaryUser { get; set; }

        public string Email { get; set; }

        public string DbUserId { get; set; }

        public string DbUserPwd { get; set; }

        public string DbName { get; set; }

        public short RoleId { get; set; }
        public int UserCode { get; internal set; }
    }
}
