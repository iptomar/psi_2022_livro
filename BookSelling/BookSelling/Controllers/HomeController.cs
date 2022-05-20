using BookSelling.Data;
using BookSelling.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace BookSelling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        private List<Advertisement> GetAdvertisements(ICollection<String> ChoosenCategory)
        {
            //PT->Percorrer as tabelas para adicionar a cada "ad"(Advertisement) o respetivo User
            //EN->Go through the tables to add to each "ad"(Advertisement) the respective User
            foreach (Advertisement ad in _context.Advertisement)
            {
                foreach (Utilizadores user in _context.Utilizadores)
                {
                    if (ad.UserID == user.UserID)
                    {
                        ad.User = user;
                    }
                }
            }
            //PT->Criar uma lista que vai receber os Ads pretendidos segundo o filtro, ou não(Caso nenhuma categoria seja escolhida)
            //EN->Create a list that will receive the pretended Ads according to the filter, or not(In the case that no category is choosen)
            List<Advertisement> ads = new List<Advertisement>();
            
            //PT->Variável auxiliar inicializada a zero para mais tarde ser usada como "flag"
            //EN->Auxiliar variable initialized at zero to later be used as a "flag"
            var aux = 0;

            //PT->Caso nenhuma categoria seja escolhida no filtro
            //EN->In case no category is choosen in the filter
            if (ChoosenCategory.Count == 0)
            {
                //PT->Cada Advertisement
                //EN->Every Advertisement
                foreach (Advertisement ad in _context.Advertisement)
                {
                    //PT->Vai ser adicionado á lista "ads"
                    //EN->Will be added to the list "ads"
                    ads.Add(ad);
                }
            }
            //PT->Caso uma ou mais categorias sejam escolhidas no filtro
            //EN->In case one or more caregories are choosen in the filter
            else
            {
                //PT->Para cada "ad"(Advertisement)
                //EN->To every "ad"(Advertisement)
                foreach (Advertisement ad in _context.Advertisement)
                {
                    //PT->Para cada categoria escolhida
                    //EN->To every category choosen
                    foreach (String category in ChoosenCategory)
                    {
                        //PT->Para cada categoria do "ad"(Advertisement)
                        //EN->To every category of "ad"(Advertisement)
                        foreach (Category cat in ad.AddCategory)
                        {
                            //PT->Se o nome da categoria do "ad"(Advertisement) for igual á categoria escolhida
                            //EN->If the name of the category of the "ad""(Advertisement) is equal to the category choosen
                            if (cat.NameCategory == category)
                            {
                                //PT->É adicionado o valor 1 á variável auxiliar
                                //EN->It's added the value 1 to the auxiliar variable
                                aux = aux + 1;
                            }
                        }
                    }
                    //PT->Depois de se ter percorrido as tabelas, se o valor da variável auxiliar for maior que zero
                    //EN->After go through the tables, if the value of the auxiliar variable is bigger than zero
                    if (aux > 0)
                    {
                        //PT->O "ad"(Advertisement) possui pelo menos uma das categorias escolhidas, logo é adicionado á lista "ads"
                        //EN->The "ad"(Advertisement) has at least one of the choosen categories, so it is added to the list "ads"
                        ads.Add(ad);
                        //PT->O valor da variável auxiliar é colocado a zero novamente
                        //EN->The value of the auxiliar variabel is reseted to zero again
                        aux = 0;
                    }
                }
            }
            //PT->Retorna a lista dos "ads" pretendidos
            //EN->Return the list of the pretended "ads"
            return ads;
        }

        public async Task<IActionResult> Index(ICollection<String> ChoosenCategory)
        {
            //PT->Criação do modelo dinamico "mymodel"
            //EN->Creation of the dynamic model "mymodel"
            dynamic mymodel = new ExpandoObject();
            //PT->Definir que o "mymodel.Advertisements" vair obter os valores retornados pelo método "GetAdvertisements(ChoosenCategory)"
            //EN->Set that the "mymodel.Advertisements" will get the values returned by the method "GetAdvertisements(ChoosenCategory)"
            mymodel.Advertisements = GetAdvertisements(ChoosenCategory);
            //PT->Retornar a view com o modelo dinamico
            //EN->Return the view with the dynamic model
            return View(mymodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}