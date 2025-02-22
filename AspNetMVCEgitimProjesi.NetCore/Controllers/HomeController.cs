using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Diagnostics;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ExcelToSql()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExcelToSql(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ViewBag.Message = "Please select a valid Excel file.";
                return View();
            }
            var sehirler = new List<string>();
            try
            {
                using (var stream = new MemoryStream())
                {
                    excelFile.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet == null)
                        {
                            ViewBag.Message = "No worksheet found in the Excel file.";
                            return View();
                        }

                        var rowCount = worksheet.Dimension.Rows;
                        var colCount = worksheet.Dimension.Columns;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            sehirler.Add(worksheet.Cells[row, 1].Value?.ToString().Trim() + "-" + worksheet.Cells[row, 2].Value?.ToString().Trim() + "-" + worksheet.Cells[row, 3].Value?.ToString().Trim() + "-" + worksheet.Cells[row, 4].Value?.ToString().Trim());
                            //var data = new YourDataModel
                            //{
                            //    Column1 = worksheet.Cells[row, 1].Value?.ToString().Trim(),
                            //    Column2 = worksheet.Cells[row, 2].Value?.ToString().Trim(),
                            //    // Map other columns as needed
                            //};

                            // Save data to the database
                            // _context.YourDataModel.Add(data);
                        }
                        ViewBag.Mes = sehirler;
                        // _context.SaveChanges();
                    }
                }

                ViewBag.Message = "Data successfully imported from Excel to SQL database.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error importing data from Excel to SQL database.");
                ViewBag.Message = "An error occurred while importing data.";
            }

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var err = HttpContext.Features.Get<IExceptionHandlerFeature>(); // hataları yakalayıp loglayabiliriz

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}