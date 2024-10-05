using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Contract;

namespace SchoolProject.Infrastrcture.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
                return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                 if (entry is null || entry.State != EntityState.Deleted || !(entry.Entity is ISoftDeleteable entity))
                //if (entry is not { State: EntityState.Deleted, Entity: ISoftDeleteable entity })
                    continue;
                entry.State = EntityState.Modified;

                entity.Delete();
            }

            return result;
        }
    }
}
