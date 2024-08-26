using SchoolManagment.Data.Entities.Identity;
using SchoolProject.Infrastrcture.InfarstrctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastrcture.Abstracts
{
    public interface IRefreshTokenRepoistory : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
