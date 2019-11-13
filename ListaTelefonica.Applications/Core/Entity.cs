using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace ListaTelefonica.Applications.Core
{
	public abstract class Entity
	{
		public Guid GuidId { get; protected set; }
		public bool Valid { get; private set; }
		public bool Invalid => !Valid;
		public ValidationResult ValidationResult { get; private set; }

		public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
		{
			ValidationResult = validator.Validate(model);
			return Valid = ValidationResult.IsValid;
		}
	}
}
