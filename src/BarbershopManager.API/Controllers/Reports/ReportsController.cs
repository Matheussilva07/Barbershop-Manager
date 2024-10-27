using BarbershopManager.Application.UseCases.Faturamento.Reports.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BarbershopManager.API.Controllers.Reports;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
	//[HttpGet]
	//[ProducesResponseType(StatusCodes.Status200OK)]
	//[ProducesResponseType(StatusCodes.Status204NoContent)]
	//public async Task<IActionResult> GenerateExcel([FromServices]IGenerateExcelReportUseCase useCase, DateOnly month)
	//{
	//	//var file = await useCase.Execute(month);

	//	//return File(file, MediaTypeNames.Application.Octet, "Relatorio-Excel.xlsx" );
	//}
}
