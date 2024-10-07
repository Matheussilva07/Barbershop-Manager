using BarbershopManager.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopManager.Domain.Entities;

[Table("Incomes")]
public class Income
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime Data_Servico { get; set; }
    public Tipo_Servico Tipo_Servico { get; set; }
    public decimal Preco { get; set; }
    public Tipo_Pagamento Tipo_Pagamento { get; set; }
}
