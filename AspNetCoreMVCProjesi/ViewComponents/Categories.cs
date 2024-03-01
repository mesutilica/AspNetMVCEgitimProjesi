using AspNetCore.Data;
using AspNetCore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCProjesi.ViewComponents
{
    public class Categories : ViewComponent // Bir class ın ViewComponent olabilmesi için ViewComponent classından miras alması gerekir.
    {
        // View Components kullanmak için ana dizindeki View > Shared klasörü içine Components isminde bir klasör eklemliyiz. Sonrasında bu klasöre de Categories isminde bir klasör ekliyoruz. Farklı komponentler kullanacaksak onlar için de bu şekilde yapmalıyız. Son olarak Categories isimli klasörün içine Default.cshtml isminde boş bir view oluşturuyoruz. Buradan veritabanından çekeceğimiz kategori listesini bu view da listeleteceğiz.
        private readonly DatabaseContext _database; // nesnemizi oluşturduktan sonra _database e sağ klik yapıp açılan menüden ampul simgesine tıklayıp, quicq action and refactoring menüsüne tıklıyoruz > Generate Constructor a tıklıyoruz 
        private readonly ICategoryService _categoryService;
        public Categories(DatabaseContext database, ICategoryService categoryService) // DI
        {
            _database = database;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() // InvokeAsync metodu asenkron bir şekilde verileri shared > components > categories altındaki default view ına gönderecek
        {
            return View(_categoryService.GetCategories()); // View(await _database.Categories.ToListAsync()); // view çalıştırılırken içinde kategori listeleyeceğimiz için modele gerekli veriyi burada gönderiyoruz.
        }

    }
}
