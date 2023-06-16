using System;

namespace MintaZHFoodHFT
{

    internal class Program
    {
        static void Main(string[] args)
        {
            FoodContext db = new FoodContext();
            Refrigerator refr = Refrigerator.LoadFromXML();

            // a) Mennyi recept van az adatbázisban ? (1, 5 pont)
            var receiptsCount = db.Receipts.Count();

            //b) Jelenítse meg a konzolon a csajozós recepteket!(1, 5 pont)
            var seductives = db.Receipts.Where(t => t.IsSeductive);

            //c) Rendezze be ár szerint csökkenő módon azokat a recepteket, amelyek alapanyagai között található Olaj
            //megnevezésű alapanyag!(4 pont)
            var receiptsWithOil = db.Receipts
                .Where(t => t.Ingredients.FirstOrDefault(z => z.Name == "Olaj") != null)
                .OrderByDescending(t=>t.Price);

            //d) Amennyiben elkészítenénk az összes receptet, melyik alapanyagból mennyire lenne szükségünk? Az
            //eredményben az alapanyag nevét és összesített darabszámát jelenítse meg oly módon, hogy az összesített
            //mennyiség szerint növekvő módon jelenjen meg!(3 pont)
            var ingredientsStat = from x in db.Ingredients
                                  group x by x.Name into g
                                  orderby g.Sum(z => z.Amount) ascending
                                  select new
                                  {
                                      IngredientName = g.Key,
                                      SumAmount = g.Sum(z => z.Amount)
                                  };

            //e) Jelenítse meg a konzolon a hűtő tartalmát. (1 pont) A megjelenítés során alkalmazza a termék
            //tulajdonságain eltárolt DisplayName attribútum értékét!(2, 5 pont)
            Console.WriteLine("Refrigerator product list");
            foreach (var item in refr.Products)
            {

            }
        }
    }
}
