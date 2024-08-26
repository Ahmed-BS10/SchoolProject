using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Abstracts;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastrcture.Repositories
{
    internal class RefreshTokenRepoistory : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepoistory
    {

        #region Fields

        private readonly DbSet<UserRefreshToken> _userRefreshTokens;

        #endregion

        #region Constructors
        public RefreshTokenRepoistory(ApplicationDbContext context) : base(context)
        {
            _userRefreshTokens = context.Set<UserRefreshToken>();
        }
        #endregion

        #region Handles Funcations

        #endregion
    }
}
