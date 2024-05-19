using FluentValidation;

namespace HMS.WebApp.Areas.Admin.Validators.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T,string> ruleBuilder)
        {
            IRuleBuilder<T, string> options = ruleBuilder.NotEmpty().WithMessage("Şifre zorunludur.")
                                            .MinimumLength(10).WithMessage("Şifreniz en az 10 karakter olmalıdır.")
                                            .Matches("[A-Z]").WithMessage("En az 1 Büyük karakter içermeli")
                                            .Matches("[a-z]").WithMessage("En az 1 Küçük karakter içermeli")
                                            .Matches("[0-9]").WithMessage("En az 1 Rakam içermeli")
                                            .Matches("[^a-zA-Z0-9]").WithMessage("En az 1 Özel karakter içermeli");
            return options;
        }
    }
}
