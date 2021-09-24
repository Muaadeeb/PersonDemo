using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDTOs;

namespace Business.Interfaces
{
	public interface IPersonManager
	{
		public Task<PersonDTO> CreatePersonAsync(PersonDTO personDto);
		public Task<PersonDTO> UpdatePersonAsync(PersonDTO personDto);
		public Task<int> DeletePersonAsync(int personId);
		public Task<IEnumerable<PersonDTO>> GetAllPersonsAsync();
		public Task<PersonDTO> GetPersonAsync(int personId);
	}
}
