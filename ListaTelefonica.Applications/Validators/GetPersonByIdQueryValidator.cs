using FluentValidation;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Querys;

namespace ListaTelefonica.Applications.Validators
{
	public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
	{
		public GetPersonByIdQueryValidator()
		{

			RuleFor(a => a)
				.NotNull()
				.WithMessage("O id é obrigatório");

		}

	}
}