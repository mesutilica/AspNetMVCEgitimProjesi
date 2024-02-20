﻿using AspNetCoreWebAPI.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost] // Slider controller da resim yükleme actionu
        public async Task<IActionResult> Upload([FromForm] IFormFile formFile, string path = "") // Metot ismi Upload, parametre olarak Iformfile ile bir formdan gelecek dosyayı alıyor
        {
            var result = await FileHelper.FileLoaderAsync(formFile, path);
            if (string.IsNullOrEmpty(result))
            {
                return Problem("Dosya Yüklenemedi!");
            }
            return Created(string.Empty, new { imageName = result }); // Geriye dosyanın eklendiğine dair response döndük
        }
    }
}
