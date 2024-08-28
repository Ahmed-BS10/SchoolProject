using System.Collections.Generic;

namespace SchoolProject.Data.DTO;

public class EditUserRolesDto
{
    public string Id { get; set; }
    public List<RolesUser> rolesUsers { get; set; }
}


public class RolesUser
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public bool HasRole { get; set; }
}

