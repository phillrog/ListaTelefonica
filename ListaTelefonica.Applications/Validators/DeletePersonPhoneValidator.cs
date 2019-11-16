using FluentValidation;
using ListaTelefonica.Applications.EntitiesApp;

namespace ListaTelefonica.Applications.Validators
{
	public class DeletePersonPhoneValidator : AbstractValidator<PersonPhoneDeleteEntity>
	{
		public DeletePersonPhoneValidator()
		{

			RuleFor(a => a.Id)
				.NotNull()
				.WithMessage("O Id do telefone é obrigatório")
				.GreaterThan(0)
				.WithMessage("O Id do telefone deve ser maior que zero");

		}
	}
}
