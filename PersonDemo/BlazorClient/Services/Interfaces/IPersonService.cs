using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelDTOs;

namespace BlazorClient.Services.Interfaces
{
	public interface IPersonService
	{
		Task<int> CreatePersonAsync(PersonDTO personDto);
		Task<int> UpdatePersonAsync(PersonDTO personDto);
		Task<int> DeletePersonAsync(int personId);
		//Task<IEnumerable<PersonDTO>> GetPersonsBySearchValueAsync(string searchValue);
		Task<PersonDTO> GetPersonByPersonIdAsync(int personId);
		public Task<IEnumerable<PersonDTO>> GetAllPersonsAsync();
	}
}
