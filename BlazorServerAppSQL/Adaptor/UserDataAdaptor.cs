using BlazorServerAppSQL.Model;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Runtime.InteropServices;

namespace BlazorServerAppSQL.Adaptor
{
    public class UserDataAdaptor : DataAdaptor
    {
        public BookingDataContext Context { get; }
        public UserDataAdaptor(BookingDataContext context)
        {
            Context = context;
        }

        

        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string additionalParam = null)
        {
            int TotalRecordsCount = await Context.UserDatas.AsNoTracking().CountAsync();
            var userDatas = Context.UserDatas.AsNoTracking();

           
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                // Filtering
                userDatas = DataOperations.PerformFiltering(userDatas, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
                //Add custom logic here if needed and remove above method
            }

            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                // Sorting
                userDatas = DataOperations.PerformSorting(userDatas, dataManagerRequest.Sorted);
                //Add custom logic here if needed and remove above method
            }

            if (dataManagerRequest.Skip != 0)
            {
                // Paging
                userDatas = DataOperations.PerformSkip(userDatas, dataManagerRequest.Skip);
                //Add custom logic here if needed and remove above method
            }
            if (dataManagerRequest.Take != 0)
            {
                // Taking
                userDatas = DataOperations.PerformTake(userDatas, dataManagerRequest.Take);
                //Add custom logic here if needed and remove above method
            }

            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = userDatas, Count = TotalRecordsCount } : (object)userDatas;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object record, string additionalParam)
        {
            if (record is UserData newUserData)
            {
                await Context.UserDatas.AddAsync(newUserData);
                return newUserData;
            }
            throw new IndexOutOfRangeException();            
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object record, string primaryColumnName, string additionalParam)
        {
            if (record is UserData changedUserData)
            {
                //Context.UserDatas.Update(changedUserData);
                Context.Attach(changedUserData);                
                Context.Entry(changedUserData).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                Context.Entry(changedUserData).State = EntityState.Detached;
                return changedUserData;
            }
            throw new IndexOutOfRangeException();
        }

        //public override async Task<object> RemoveAsync(DataManager dataManager, object primaryColumnValue, string primaryColumnName, string additionalParam)
        //{
        //    if (record is UserData changedUserData)
        //    {
        //        //Context.UserDatas.Update(changedUserData);
        //        Context.Attach(changedUserData);
        //        Context.Entry(changedUserData).State = EntityState.Modified;
        //        await Context.SaveChangesAsync();
        //        Context.Entry(changedUserData).State = EntityState.Detached;
        //        return changedUserData;
        //    }
        //    throw new IndexOutOfRangeException();
        //}


    }
}
