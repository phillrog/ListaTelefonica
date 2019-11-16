using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Contexts;
using ListaTelefonica.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Infra.Data.Repositories
{
	public class PersonRepository : RepositoryBase<Person>, IPersonRepository
	{
		private readonly IContext _context;

		public PersonRepository(IContext context) : base(context)
		{
			_context = context;
		}

		public override void Update(Person entity)
		{
			_context.PersonPhone.AttachRange(entity.Phones);

			foreach (var phone in entity.Phones)
			{
				_context.Entry(phone).State = EntityState.Modified;
			}
			
			base.Update(entity);
		}
	}
}