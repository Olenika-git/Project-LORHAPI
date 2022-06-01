using LORHAPI_API.Data;
using LORHAPI_API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public class InsertionRepository : IInsertionRepository
    {
        private List<Insertion> InsertionList = new();
        private readonly Db_Context _dbcontext;

        public InsertionRepository(Db_Context context)
        {
            _dbcontext = context;  //on assigne le Db_Context
            InsertionList = _dbcontext.Insertions.ToList();
        }

        public async Task<List<Insertion>> GetInsertionAsync()
        {
            return await Task.FromResult(InsertionList);
        }

        public async Task<Insertion> GetInsertionByIdAsync(int id)
        {
            Insertion insertion = InsertionList.Where(theInsertion => theInsertion.IdInsertion == id).SingleOrDefault();
            return await Task.FromResult(insertion);
        }

        public async Task CreateInsertionAsync(Insertion insertion)
        {
            if (insertion == null)
            {
                return;
            }
            else
            {
                InsertionList.Add(insertion);
                _dbcontext.Add(insertion);
                await _dbcontext.SaveChangesAsync();
            }


            await Task.CompletedTask;
        }

        public async Task UpdateInsertionAsync(Insertion insertion)
        {
            int insertionIndex = InsertionList.FindIndex(ExistingInsertion => ExistingInsertion.IdInsertion == insertion.IdInsertion);

            if (insertionIndex == -1)
            {
                return;
            }
            else
            {
                InsertionList[insertionIndex] = insertion;
                _dbcontext.Update(insertion);
                await _dbcontext.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }

        public async Task DeleteInsertionAsync(int id)
        {
            int insertionIndex = InsertionList.FindIndex(ExistingInsertion => ExistingInsertion.IdInsertion == id);
            Insertion insertion = InsertionList.Where(theInsertion => theInsertion.IdInsertion == id).SingleOrDefault();

            if (insertionIndex == -1 || insertionIndex == 0)
            {
                return;
            }
            else
            {
                InsertionList.RemoveAt(insertionIndex);
                _dbcontext.Remove(insertion);
                await _dbcontext.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }

    }
}
