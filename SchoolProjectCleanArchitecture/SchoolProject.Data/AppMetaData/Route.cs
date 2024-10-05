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
            public const string EditUserClaims = $"{Prefix}EditUserClaims";




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
        
        public static class Authentication
        {
            public const string Prefix = $"{Rule}Authentication/";
            public const string SignIn = $"{Prefix}SignIn";
            public const string ConfirmEmail = $"Api/Authentication/ConfirmEmail";
            public const string SendResetPasswordCode = $"Api/Authentication/SendResetPasswordCode";
            public const string ConfirmResetPassword = $"Api/Authentication/ConfirmResetPassword";
            public const string UpdatePassword = $"Api/Authentication/UpdatePassword";
            

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



        public static class InstructorRouting
        {
            public const string Prefix = $"{Rule}Instructor/";
            public const string List = $"{Prefix}List";
            public const string Create = $"{Prefix}Create";
            public const string Delete = $"{Prefix}Delete{"Id"}";
            public const string Edit = $"{Prefix}Edit";

        }

    }
}
