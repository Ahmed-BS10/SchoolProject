using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Route
    {
        public const string root = "Api";
        public const string version  = "V1";
        public const string Rule  = $"{root}/{version}/";


        public static class AuthorizationRouting
        {
            public const string Prefix = $"{Rule}Authorization/";
            public const string GetById = $"{Prefix}{"Id"}";
            public const string GetList = $"{Prefix}GetList";
            public const string AddRole = $"{Prefix}Role/Create";
            public const string EditRole = $"{Prefix}Role/Edit";
            public const string DeleteRole = $"{Prefix}Role/Delete/{"id"}";
            public const string GetUserWithRoles = $"{Prefix}GetUserWithRoles";
            public const string UserClaims = $"{Prefix}UserClaims";
            public const string EditUserRoles = $"{Prefix}EditUserRoles";




        }

        public static class StudentRouting
        {
            public const string Prefix = $"{Rule}Student/";
            public const string Pagination = $"{Prefix}Pagination";
            public const string List = $"{Prefix}List";
            public const string GetWithIncludeById = $"{Prefix}WithInclude{"Id"}";
            public const string GetById = $"{Prefix}{"Id"}";
            public const string Create = $"{Prefix}Create";
            public const string Edit = $"{Prefix}Edit";
            public const string Delete = $"{Prefix}Delete{"Id"}";

        }


        public static class UserRouting
        {
            public const string Prefix = $"{Rule}User/";
            public const string Pagination = $"{Prefix}Pagination";
            public const string List = $"{Prefix}List";
            public const string GetWithIncludeById = $"{Prefix}WithInclude{"Id"}";
            public const string GetById = $"{Prefix}{"Id"}";
            public const string Create = $"{Prefix}Create";
            public const string Edit = $"{Prefix}Edit";
            public const string ChangePassword = $"{Prefix}ChangePassword";
            public const string Delete = $"{Prefix}Delete{"Id"}";


        }
        
        public static class Authencation
        {
            public const string Prefix = $"{Rule}Authencation/";
            public const string SignIn = $"{Prefix}SignIn";
            

        }



        public static class DepartmentRouting
        {
            public const string Prefix = $"{Rule}Student/";
            public const string Pagination = $"{Prefix}Pagination";
            public const string List = $"{Prefix}List";
            public const string GetWithIncludeById = $"{Prefix}WithInclude{"Id"}";
            public const string GetById = $"{Prefix}{"Id"}";
            public const string Create = $"{Prefix}Create";
            public const string Edit = $"{Prefix}Edit";
            public const string Delete = $"{Prefix}Delete{"Id"}";

        }

    }
}
