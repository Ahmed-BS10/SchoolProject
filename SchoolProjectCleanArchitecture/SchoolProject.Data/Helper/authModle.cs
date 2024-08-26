using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolProject.Data.Helper
{
    //    public class JWTAuthResult
    //    {

    //        public string AccessToken { get; set; }

    //        public RefreshToken RefreshToken { get; set; }
    //    }
    //    public class RefreshToken
    //    {
    //        public string UserName { get; set; }
    //        public string AccessRefreshTokenToken { get; set; }
    //        public DateTime ExpireAt { get; set; }
    //    }

    public class authModle
    {
        public string Token { get; set; }
        [JsonIgnore]
        public string ResreshToken { get; set; }
        public DateTime RefreshTokenExpiresOn { get; set; }
    }

}

