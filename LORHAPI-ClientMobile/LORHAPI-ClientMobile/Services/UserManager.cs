using LORHAPI_ModelClientMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LORHAPI_ClientMobile.Services
{
	public class UserManager
	{
		IRestService restService;

		public UserManager(IRestService service)
		{
			restService = service;
		}

		public Task<List<User>> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task SaveTaskAsync(User user, bool isNewUser = false)
		{
			return restService.SaveTodoItemAsync(user, isNewUser);
		}

		public Task DeleteTaskAsync(User user)
		{
			return restService.DeleteTodoItemAsync(user.IdClient);
		}
	}
}
