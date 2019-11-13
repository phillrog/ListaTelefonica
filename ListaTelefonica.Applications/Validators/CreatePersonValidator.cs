using FluentValidation;
using ListaTelefonica.Applications.EntitiesApp;

namespace ListaTelefonica.Applications.Validators
{
	public class CreatePersonValidator : AbstractValidator<PersonEntity>
	{
		public CreatePersonValidator()
		{
		
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
				.SetValidator(model => new CreatePersonPhoneValidator(model));
		}
	}

	public class CreatePersonPhoneValidator : AbstractValidator<PersonPhoneEntity>
	{
		public CreatePersonPhoneValidator(PersonEntity model)
		{

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
