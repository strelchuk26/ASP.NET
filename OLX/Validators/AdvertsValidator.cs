using FluentValidation;
using DataAccess.Entities;

namespace OLX.Validators
{
	public class AdvertsValidator : AbstractValidator<Advert>
	{
		public AdvertsValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).NotNull().MaximumLength(100);
			RuleFor(x => x.CategoryId).GreaterThan(0);
			RuleFor(x => x.Description).Length(10, 1000);
			RuleFor(x => x.Location).NotNull();
			RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(1);
		}
	}
}
