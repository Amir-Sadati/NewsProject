using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities
{
    public class Users :IdentityUser
    {
       [NotMapped]
       public string DisplayName { get => $"{FirstName} {LastName}"; }
       public string FirstName { get; set; }
       public string LastName { get; set; }

    }
}
