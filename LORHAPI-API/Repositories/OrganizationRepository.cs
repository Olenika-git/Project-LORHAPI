using LORHAPI_API.Data;
using LORHAPI_API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private List<Organization> OrganizationList = new();
        private readonly Db_Context _dbcontext;

        public OrganizationRepository(Db_Context context)
        {
            _dbcontext = context;  //on assigne le Db_Context
            OrganizationList = _dbcontext.Organizations.ToList();
        }

        public async Task<List<Organization>> GetOrganizationAsync()
        {
            return await Task.FromResult(OrganizationList);
        }

        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            Organization organization = OrganizationList.Where(theOrganization => theOrganization.IdOrganization == id).SingleOrDefault();
            return await Task.FromResult(organization);
        }
        
        public async Task CreateOrganizationAsync(Organization organization)
        {
            if (organization == null)
            {
                return;
            }
            else
            {
                OrganizationList.Add(organization);
                _dbcontext.Add(organization);
                await _dbcontext.SaveChangesAsync();
            }

            
            await Task.CompletedTask;
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            int OrganizationIndex = OrganizationList.FindIndex(ExistingOrga => ExistingOrga.IdOrganization == organization.IdOrganization);
            
            if (OrganizationIndex == -1)
            {
                return;
            }
            else
            {
                OrganizationList[OrganizationIndex] = organization;
                _dbcontext.Update(organization);
                await _dbcontext.SaveChangesAsync();
            }
            
            await Task.CompletedTask;
        }
        
        public async Task DeleteOrganizationAsync(int id)
        {
            int OrganizationIndex = OrganizationList.FindIndex(ExistingOrga => ExistingOrga.IdOrganization == id);
            Organization organization = OrganizationList.Where(ExistingOrga => ExistingOrga.IdOrganization == id).SingleOrDefault();

            if (OrganizationIndex == -1 || OrganizationIndex == 0)
            {
                return;
            }
            else
            {
                OrganizationList.RemoveAt(OrganizationIndex);
                _dbcontext.Remove(organization);
                await _dbcontext.SaveChangesAsync();
            }
            
            await Task.CompletedTask;
        }
    }
}
