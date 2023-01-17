using AzureADBlazor.Server.Implementations;
using AzureADBlazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AzureADBlazor.Server.Controllers
{
    [ApiController]
    [Route("/PDFBytes")]
    public class PDFController : ControllerBase
    { 
        private readonly ILogger<PDFController> _logger;

        public PDFController(ILogger<PDFController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HelloWorldPDF GetPDF()
        {
            var generateService = new GenerateService();
            var pdf = generateService.GeneratePDF();


            return new HelloWorldPDF { pdfBits = pdf };

        }
    }
} 