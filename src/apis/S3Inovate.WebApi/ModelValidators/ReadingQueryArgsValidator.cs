using FluentValidation;
using S3Inovate.Core.Cqrs.Queries;

namespace S3Inovate.WebApi.ModelValidators
{
    public class ReadingQueryArgsValidator : AbstractValidator<ReadingQuery>
    {
        public ReadingQueryArgsValidator()
        {
            RuleFor(r => r.BuildingId).NotNull().WithMessage("Building Required");
            RuleFor(r => r.ObjectId).NotNull().WithMessage("Object Required");
            RuleFor(r => r.DataFieldId).NotNull().WithMessage("Data Field Required");
            RuleFor(r => r.FromDate).NotNull().WithMessage("From Date Required");
            RuleFor(r => r.ToDate).NotNull().WithMessage("To Date Required");
            RuleFor(r => r.ToDate)
                .GreaterThanOrEqualTo(r => r.FromDate)
                .WithMessage("To Date must be greater than or equal to From Date");
        }
    }
}
