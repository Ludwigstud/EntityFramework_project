using EntityFrameworkTest.Models.Forms;

namespace EntityFrameworkTest.Services;
internal class MenuService
{
    private readonly ProductService _productService = new ProductService();

    public async Task MainMenu()
    {
        Console.Clear();
        Console.WriteLine("##### HUVUDMENY #####");
        Console.WriteLine("1. Skapa en ny produkt");
        Console.WriteLine("2. Visa alla produkter");
        Console.WriteLine("3. Visa specifik produkt");
        Console.Write("\nAnge ett av följade alternativ (1-3): ");
        var option = Console.ReadLine();




        switch (option)
        {


            case "1":
                await CreateMenu();
                break;


            case "2":
                await ShowAllMenu();
                break;


            case "3":
                await ShowSpecificMenu();
                break;

                





        }

        Console.ReadKey();

    }



    public async Task CreateMenu()
    {

        var form = new ProductRegistrationForm();

        Console.Clear();
        Console.WriteLine("##### SKAPA NU PRODUKT #####");
        Console.Write("Artikelnummer: "); form.ArticleNumber = Console.ReadLine() ?? "";
        Console.Write("Produktnamn: "); form.Name = Console.ReadLine() ?? "";
        Console.Write("Kategori: "); form.CategoryName = Console.ReadLine() ?? "";
        Console.Write("Pris: "); form.StockPrice = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Produktbeskrivning: "); form.Description = Console.ReadLine() ?? "";

        var result = await _productService.CreateAsync(form);

        if (result == null)
            Console.WriteLine("\nDet finns redan en produkt med samma artikelnummer:");
        else
            Console.WriteLine($"Produkten med artikelnummer {result.ArticleNumber} Har skapats.");


    }



    public async Task ShowAllMenu()
    {
        Console.Clear();
        Console.WriteLine("##### VISAR ALLA PRODUKTER #####\n");
        foreach (var product in await _productService.GetAllAsync())
            Console.WriteLine($"{product.ArticleNumber} {product.Name} {product.StockPrice} SEK");


    }



    public async Task ShowSpecificMenu()
    {
        await ShowAllMenu();

        Console.Write("Ange Artikelnummer: ");
            var articleNumber = Console.ReadLine();


        if (!string.IsNullOrEmpty(articleNumber))
        {

            var product = await _productService.GetAsync(articleNumber);

            if(product != null)
            {

                Console.Clear();
                Console.WriteLine("##### PRODUKTINFORMATION ######");
                Console.WriteLine($"Artikelnummer: {product.ArticleNumber}");
                Console.WriteLine($"Produktnamn: {product.Name}");
                Console.WriteLine($"Pris: {product.StockPrice} SEK");
                Console.WriteLine($"Kategori: {product.Category.Name}");
                Console.WriteLine($"Produktbeskrivning: {product.Description}");
            }
            else
            {

                Console.WriteLine($"\nIngen artikel med artikelnummer {articleNumber} kunde hittas.");


            }


        }

        else
        {

            Console.WriteLine("Ingen artikelnummer specificerades.");

        }


    }







}
