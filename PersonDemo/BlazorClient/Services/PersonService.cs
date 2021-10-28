using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorClient.Services.Interfaces;
using ModelDTOs;
using Newtonsoft.Json;

namespace BlazorClient.Services
{
	public class PersonService : IPersonService
	{
		private readonly HttpClient _httpClient;

		public PersonService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> CreatePersonAsync(PersonDTO personDto)
		{
			JsonContent content = JsonContent.Create(personDto);
			HttpResponseMessage response = await _httpClient.PutAsync($"/api/person/createperson", content);

			if (response.IsSuccessStatusCode)
			{
				return 0;
			}

			return 1;
		}

		public async Task<int> UpdatePersonAsync(PersonDTO personDto)
		{
			JsonContent content = JsonContent.Create(personDto);
			HttpResponseMessage response = await _httpClient.PostAsync($"/api/person/updateperson", content);
            
			if (response.IsSuccessStatusCode)
			{
				return 0;
			}

			return 1;
		}

		public async Task<int> DeletePersonAsync(int personId)
		{
			var response = await _httpClient.DeleteAsync($"/api/person/deletepersonbypersonid?personId={personId}");
			return 0;
		}

		public async Task<PersonDTO> GetPersonByPersonIdAsync(int personId)
		{
			var response = await _httpClient.GetAsync($"/api/person/getpersonbypersonid?personId={personId}");
			var result = await PersonMapping(response);
			return result.FirstOrDefault();
		}

		public async Task<IEnumerable<PersonDTO>> GetAllPersonsAsync()
		{
			var response = await _httpClient.GetAsync("/api/person/getallpersons");
			return await PersonMapping(response);
		}


		private async Task<IEnumerable<PersonDTO>> PersonMapping(HttpResponseMessage response)
		{
			try
			{
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(content);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
