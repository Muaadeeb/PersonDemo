using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ModelDTOs;

namespace Business.Managers
{
	public class PersonManager : IPersonManager
	{
		private ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public PersonManager(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<PersonDTO> CreatePersonAsync(PersonDTO personDto)
		{
			var person = _mapper.Map<PersonDTO, Person>(personDto);
			var addedPerson = await _context.Persons.AddAsync(person);
			await _context.SaveChangesAsync();
			return _mapper.Map<Person, PersonDTO>(addedPerson.Entity);
		}

		public async Task<PersonDTO> UpdatePersonAsync(PersonDTO personDto)
		{
			var personDetails = await _context.Persons.FindAsync(personDto.PersonId);
			var person = _mapper.Map<PersonDTO, Person>(personDto, personDetails);

			var updatedPerson = _context.Persons.Update(person);
			await _context.SaveChangesAsync();

			return _mapper.Map<Person, PersonDTO>(updatedPerson.Entity);
		}

		public async Task<int> DeletePersonAsync(int personId)
		{
			var personDetails = await _context.Persons.FindAsync(personId);
			if(personDetails != null)
			{
				_context.Persons.Remove(personDetails);
				return await _context.SaveChangesAsync();
			}

			return default;
		}

		public async Task<IEnumerable<PersonDTO>> GetAllPersonsAsync()
		{
			return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(await _context.Persons.ToListAsync());
		}

		public async Task<PersonDTO> GetPersonAsync(int personId)
		{
			var personData = await _context.Persons.FirstOrDefaultAsync((x => x.PersonId == personId));

			if (personData == null)
			{
				return default;
			}

			return _mapper.Map<Person, PersonDTO>(personData);
		}
	}
}
