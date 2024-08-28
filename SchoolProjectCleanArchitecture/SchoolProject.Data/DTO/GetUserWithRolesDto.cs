using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.DTO;


public class GetUserWithRolesDto
    {
        public string Id { get; set; }
        public List<Roles> roles { get; set; }
    }


    public class Roles
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }

