using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Recodme.RD.Lennyouse.DataLayer.UserInfo
{
    public class LennyouseUser : IdentityUser<Guid>
    {
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
       
        public override Guid Id { get; set; }

        public virtual Person Person { get; set; }
    }
}
