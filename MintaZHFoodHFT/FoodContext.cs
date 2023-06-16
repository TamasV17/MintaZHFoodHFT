using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZHFoodHFT
{
    internal class FoodContext: DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Receipts> Receipts { get; set; }

        public FoodContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FoodReceipts.mdf;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .HasOne(t => t.Receipt)
                .WithMany(t => t.Ingredients)
                .HasForeignKey(t => t.ReceiptId);

            var carb = new Receipts() { Id = 1, Name = "Carbonara", Price = 1400 };
            var bolo = new Receipts() { Id = 2, Name = "Bolognai", Price = 900 };
            var gt = new Receipts() { Id = 3, Name = "Grízes tészta", Price = 400, IsSeductive = true };
            var lasa = new Receipts() { Id = 4, Name = "Lasagne", Price = 1600, IsSeductive = true };
            var pk = new Receipts() { Id = 5, Name = "Paprikás krumpli", Price = 700 };
            var lecso = new Receipts() { Id = 6, Name = "Lecsó", Price = 850 };

            modelBuilder.Entity<Receipts>().HasData(carb, bolo, gt, lasa, pk, lecso);

            var ingredients = new List<Ingredient>()
            {
                // Carb
                new Ingredient() { Id = 1, Name = "Spagetti tészta", Amount = 1, ReceiptId = carb.Id },
                new Ingredient() { Id = 2, Name = "Tojás", Amount = 4, ReceiptId = carb.Id },
                new Ingredient() { Id = 3, Name = "Só", Amount = 1, ReceiptId = carb.Id },
                new Ingredient() { Id = 4, Name = "Bors", Amount = 1, ReceiptId = carb.Id },
                new Ingredient() { Id = 5, Name = "Bacon", Amount = 5, ReceiptId = carb.Id },
                // Bolo
                new Ingredient() { Id = 6, Name = "Spagetti tészta", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 7, Name = "Paradicsom szósz", Amount = 3, ReceiptId = bolo.Id },
                new Ingredient() { Id = 8, Name = "Hagyma", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 9, Name = "Darálthús", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 10, Name = "Oregánó", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 11, Name = "Só", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 12, Name = "Bors", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 13, Name = "Olaj", Amount = 1, ReceiptId = bolo.Id },
                // Gt
                new Ingredient() { Id = 14, Name = "Lapos tészta", Amount = 2, ReceiptId = gt.Id },
                new Ingredient() { Id = 15, Name = "Gríz", Amount = 2, ReceiptId = gt.Id },
                new Ingredient() { Id = 16, Name = "Olaj", Amount = 2, ReceiptId = gt.Id },
                new Ingredient() { Id = 17, Name = "Lekvár", Amount = 1, ReceiptId = gt.Id },
                // Lasa
                new Ingredient() { Id = 18, Name = "Nagy lapos tészta", Amount = 2, ReceiptId = lasa.Id },
                new Ingredient() { Id = 19, Name = "Paradicsom szósz", Amount = 3, ReceiptId = lasa.Id },
                new Ingredient() { Id = 20, Name = "Hagyma", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 21, Name = "Darálthús", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 22, Name = "Oregánó", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 23, Name = "Só", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 24, Name = "Bors", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 25, Name = "Olaj", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 26, Name = "Besamel", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 27, Name = "Sajt", Amount = 1, ReceiptId = lasa.Id },
                // PK
                new Ingredient() { Id = 28, Name = "Krumpli", Amount = 10, ReceiptId = pk.Id },
                new Ingredient() { Id = 29, Name = "Hagyma", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 30, Name = "Kolbász", Amount = 2, ReceiptId = pk.Id },
                new Ingredient() { Id = 31, Name = "Fűszer paprika", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 32, Name = "Só", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 33, Name = "Bors", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 34, Name = "Majoranna", Amount = 1, ReceiptId = pk.Id },
                // Lecso
                new Ingredient() { Id = 35, Name = "Paprika", Amount = 6, ReceiptId = lecso.Id },
                new Ingredient() { Id = 36, Name = "Paradicsom", Amount = 4, ReceiptId = lecso.Id },
                new Ingredient() { Id = 37, Name = "Hagyma", Amount = 1, ReceiptId = lecso.Id },
                new Ingredient() { Id = 38, Name = "Só", Amount = 1, ReceiptId = lecso.Id },
                new Ingredient() { Id = 39, Name = "Bors", Amount = 1, ReceiptId = lecso.Id },
            };

            modelBuilder.Entity<Ingredient>().HasData(ingredients);


            base.OnModelCreating(modelBuilder);
        }
    }
}
