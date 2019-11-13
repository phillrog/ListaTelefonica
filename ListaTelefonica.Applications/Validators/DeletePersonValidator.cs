using System.Linq;
using FluentValidation;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Core;

namespace ListaTelefonica.Applications.Validators
{
	public class DeletePersonValidator : AbstractValidator<PersonDeleteEntity>
	{
		public DeletePersonValidator()
		{

			RuleFor(a => a.Id)
				.NotNull()
				.WithMessage("O Id da pessoa é obrigatório")
				.GreaterThan(0)
				.WithMessage("O Id da pessoa deve ser maior que zero");

		}
	}
}
