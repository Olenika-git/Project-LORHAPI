using LORHAPI_ModelClientMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LORHAPI_ClientMobile.Services
{
	public interface IRestService
	{
		Task<List<User>> RefreshDataAsync();

		Task SaveTodoItemAsync(User user, bool isNewUser);

		Task DeleteTodoItemAsync(int id);
	}
}
