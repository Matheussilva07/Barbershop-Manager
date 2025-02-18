using BarbershopManager.Communication.Enums;

namespace BarbershopManager.Communication.Requests.Incomes;
public class RequestRegisterIncomeJson
{
    public string Nome { get; set; } = string.Empty;
    public DateTime Data_Servico { get; set; }
    public Tipo_Servico Tipo_Servico { get; set; }
    public decimal Preco { get; set; }
    public Tipo_Pagamento Tipo_Pagamento { get; set; }
}
