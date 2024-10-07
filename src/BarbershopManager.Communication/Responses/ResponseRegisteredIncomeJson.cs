using BarbershopManager.Communication.Enums;

namespace BarbershopManager.Communication.Responses;
public class ResponseRegisteredIncomeJson
{
	public string Nome { get; set; } = string.Empty;
	public DateTime Data_Servico { get; set; }
	public Tipo_Servico Tipo_Servico { get; set; }
}
