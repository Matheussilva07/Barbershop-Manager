using BarbershopManager.Communication.Enums;

namespace BarbershopManager.Communication.Responses;
public class ResponseShortIncomesJson
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
	public DateTime Data_Servico { get; set; }
	public Tipo_Servico Tipo_Servico { get; set; }
}
