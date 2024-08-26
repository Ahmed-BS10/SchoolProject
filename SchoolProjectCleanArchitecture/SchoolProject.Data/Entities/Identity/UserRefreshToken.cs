using SchoolProject.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities.Identity
{
    //public class UserRefreshToken
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string UserId { get; set; }
    //    public string? Token { get; set; }
    //    public string? RefreshToken { get; set; }
    //    public string? JwtId { get; set; }

    //    public bool IsUsed { get; set; }
    //    public bool IsRevoked { get; set; }
    //    public DateTime ExpiryDate { get; set; }
    //    public DateTime CreatedAt { get; set; }

    //    [ForeignKey(nameof(UserId))]
    //    public ApplicationUser? ApplicationUser { get; set; }
    //}

    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Token { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsExpiresOn => DateTime.UtcNow >= ExpiresOn;
        public bool IsActive => RevokedOn == null && !IsExpiresOn;
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
