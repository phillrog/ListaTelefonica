using System.Linq;
using FluentValidation;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Core;

namespace ListaTelefonica.Applications.Validators
{
	public class UpdatePersonValidator : AbstractValidator<PersonUpdateEntity>
	{
		public UpdatePersonValidator()
		{

			RuleFor(a => a.Id)
				.NotNull()
				.WithMessage("O Id é obrigatório")
				.GreaterThan(0)
				.WithMessage("O Id deve ser maior que zero");

			RuleFor(a => a.Name)
				.NotEmpty()
				.WithMessage("O Nome é obrigatório")
				.MaximumLength(100)
				.WithMessage("Tamanho do nome é inválido, máximo tamanho de 100 caracteres");
				
				 
			RuleFor(a => a.DateBirth)
				.NotNull()
				.WithMessage("Data de nascimento é obrigatório");

			RuleFor(a => a.Phones)
				.NotNull()
				.WithMessage("Informe pelo menos um telefone");

			RuleForEach(model => model.Phones)
				.SetValidator(model => new UpdatePersonPhoneValidator(model));
		}
	}

	public class UpdatePersonPhoneValidator : AbstractValidator<PersonPhoneUpdateEntity>
	{
		public UpdatePersonPhoneValidator(PersonUpdateEntity model)
		{
			RuleFor(a => a.Id)
				.NotNull()
				.WithMessage("O Id do telefone é obrigatório")
				.GreaterThan(0)
				.WithMessage("O Id do telefone deve ser maior que zero");

			RuleFor(a => a.Description)
				.NotEmpty()
				.WithMessage("A descrição do telefone é obrigatório")
				.DependentRules(() =>
				{
					RuleFor(d2 => d2.Description).MaximumLength(100)
						.WithMessage("Tamanho da descrição do telefone é inválido, máximo tamanho de 100 caracteres");
				}); 

			RuleFor(a => a.Number)
				.NotEmpty()
				.WithMessage("O número do telefone é obrigatório")
				.DependentRules(() =>
				{
					RuleFor(d2 => d2.Number).MaximumLength(20)
						.WithMessage("Tamanho do número de telefone é inválido, máximo tamanho de 20 caracteres");
				}); 
		}
	}
}
