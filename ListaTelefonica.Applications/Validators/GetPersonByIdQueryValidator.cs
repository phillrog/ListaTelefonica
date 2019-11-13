using FluentValidation;
using ListaTelefonica.Applications.EntitiesApp;

namespace ListaTelefonica.Applications.Validators
{
	public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQueryEntity>
	{
		public GetPersonByIdQueryValidator()
		{

			RuleFor(a => a)
				.NotNull()
				.WithMessage("O id da pessoa é obrigatório");

		}

	}
}