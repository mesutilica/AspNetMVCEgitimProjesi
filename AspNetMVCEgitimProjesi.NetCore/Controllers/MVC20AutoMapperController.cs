using AspNetCoreMVCEgitimKonulari.Dtos;
using AspNetMVCEgitimProjesi.NetCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC20AutoMapperController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UyeContext _context;
        public MVC20AutoMapperController(IMapper mapper, UyeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            var uye = _context.Uyeler.FirstOrDefault();
            if (uye != null)
            {
                var uyeDtoNesnesi = _mapper.Map<UyeDto>(uye);
                ViewBag.Email = uyeDtoNesnesi.Email;
                ViewBag.Password = uyeDtoNesnesi.Password;
            }
            var Uyeler = _context.Uyeler.ToList();
            var uyeDtoListesi = new List<UyeListDto>();
            if (Uyeler != null)
            {
                foreach (Uye item in Uyeler)
                {
                    uyeDtoListesi.Add(new UyeListDto
                    {
                        Email = item.Email,
                        Ad = item.Ad,
                        DogumTarihi = item.DogumTarihi,
                        Soyad = item.Soyad,
                        TcKimlikNo = item.TcKimlikNo,
                        Telefon = item.Telefon
                    });
                }
            }
            var uyeDtoListesiMap = _mapper.Map<List<UyeListDto>>(Uyeler);
            return View(uyeDtoListesiMap);
        }
    }
}
