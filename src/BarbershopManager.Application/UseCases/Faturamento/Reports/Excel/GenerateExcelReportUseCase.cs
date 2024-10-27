
using BarbershopManager.Domain.IncomeRepository;
using ClosedXML.Excel;

namespace BarbershopManager.Application.UseCases.Faturamento.Reports.Excel;
public class GenerateExcelReportUseCase : IGenerateExcelReportUseCase
{
    private readonly IIncomesRepository _repository;
	public GenerateExcelReportUseCase(IIncomesRepository repository)
    {
        this._repository = repository;
    }
 //   public async Task<byte[]> Execute(DateOnly month)
	//{
 //       var incomes = await _repository.GetAll();

 //       if(incomes.Count == 0)
 //       {
 //            return [];
 //       }

 //       using var workBook = new XLWorkbook();
 //       workBook.Author = "Matheus Santana";
 //       workBook.Style.Font.FontSize = 12;
 //       workBook.Style.Font.FontColor = XLColor.Black;
 //       workBook.Style.Font.FontName = "Arial";

 //       var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

       


	//}
}
