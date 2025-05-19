using AspNetCoreMVCEgitimKonulari.Dtos;
using AspNetMVCEgitimProjesi.NetCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC20DtoAutoMapperController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UyeContext _context;
        public MVC20DtoAutoMapperController(IMapper mapper, UyeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            var uye1 = _context.Uyeler.FirstOrDefault();
            if (uye1 != null)
            {
                var uyeDtoNesnesi = _mapper.Map<UyeDto>(uye1);
                ViewBag.Email = uyeDtoNesnesi.Email;
                ViewBag.Password = uyeDtoNesnesi.Password;
            }
            var Uyeler = _context.Uyeler.ToList();
            var uyeDtoListesi = new List<UyeListDto>();
            var uyeDtoListesi2 = new List<UyeListDto>();
            if (Uyeler != null)
            {
                // Yöntem 1: ForEach ile listeye ekleme
                foreach (Uye uye in Uyeler)
                {
                    uyeDtoListesi.Add(new UyeListDto
                    {
                        Email = uye.Email,
                        Ad = uye.Ad,
                        DogumTarihi = uye.DogumTarihi,
                        Soyad = uye.Soyad,
                        TcKimlikNo = uye.TcKimlikNo,
                        Telefon = uye.Telefon
                    });
                }
                // Yöntem 2: Linq ile listeye ekleme
                uyeDtoListesi2 = Uyeler.Select(item => new UyeListDto
                {
                    Email = item.Email,
                    Ad = item.Ad,
                    DogumTarihi = item.DogumTarihi,
                    Soyad = item.Soyad,
                    TcKimlikNo = item.TcKimlikNo,
                    Telefon = item.Telefon
                }).ToList();
            }
            // Yöntem 3: AutoMapper ile listeye ekleme
            var uyeDtoListesiMap = _mapper.Map<List<UyeListDto>>(Uyeler);
            return View(uyeDtoListesi2); //uyeDtoListesi, uyeDtoListesiMap
        }
    }
}
