using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace BarbershopManager.Application.UseCases.Users.Register;
public class PasswordValidator<T> : PropertyValidator<T, string>
{
	private const string ERROR_MESSAGE = "ErrorMessage";
	public override string Name => "PasswordValidator";

	protected override string GetDefaultMessageTemplate(string errorCode)
	{
		return $"{{{ERROR_MESSAGE}}}";
	}
	public override bool IsValid(ValidationContext<T> context, string password)
	{
		if (string.IsNullOrWhiteSpace(password))
		{
			context.MessageFormatter.AppendArgument(ERROR_MESSAGE, "Senha vazia!");
			return false;
		}
		if(password.Length < 8)
		{
			context.MessageFormatter.AppendArgument(ERROR_MESSAGE, "A senha deve conter pelo menos 8 caracteres!");
			return false;
		}
		if(Regex.IsMatch(password, @"[A-Z]+") == false)
		{
			context.MessageFormatter.AppendArgument(ERROR_MESSAGE, "A senha deve conter pelo menos um caracter maiúsculo!");
			return false;
		}
		if (Regex.IsMatch(password,@"[a-z]+") == false)
		{
			context.MessageFormatter.AppendArgument(ERROR_MESSAGE, "A senha deve conter pelo menos um caracter minúsculo!");
			return false;
		}
		if (Regex.IsMatch(password, @"[0-9]+") == false)
		{
			context.MessageFormatter.AppendArgument(ERROR_MESSAGE, "A senha deve conter pelo menos um número!");
			return false;
		}
		if (Regex.IsMatch(password, @"[\!\#\*]+") == false)
		{
			context.MessageFormatter.AppendArgument(ERROR_MESSAGE, "A senha deve conter pelo menos um caracter especial!");
			return false;
		}

		return true;
	}
}
