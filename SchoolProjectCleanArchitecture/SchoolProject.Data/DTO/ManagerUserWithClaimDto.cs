namespace SchoolProject.Data.DTO;

public class ManagerUserWithClaimDto
{
    public string Id { get; set; }
    public List<ClaimsUser> claimsUsers { get; set; }
}


public class ClaimsUser
{
    public string type { get; set; }
    public bool value { get; set; }
}




