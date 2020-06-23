using Recodme.RD.Lennyouse.DataLayer.IdentifyUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.UserInfo
{
    public class LennyouseUser : IdUser
    {
        public Guid Id { get; private set; }

        public virtual Person Person { get; set; }
    }
}
