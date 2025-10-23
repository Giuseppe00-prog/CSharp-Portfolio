using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class ECommerceContext : DbContext
    {
        public DbSet<Prodotto> Prodotti {  get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Cliente> Clienti { get; set; }

        public DbSet<Ordine> Ordini { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Creazione database locale nella cartella del progetto
            //Utilizzo un path assoluto perché altrimenti viene creato un db nell'Ecommerce.Data
            optionsBuilder.UseSqlite($"Data Source=C:\\Users\\giuse\\Desktop\\Informatica\\CorsoCSharp\\Portfolio\\Ecommerce\\Ecommerce\\ecommerce.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prodotto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Prodotti)
                .HasForeignKey(p => p.CategoriaId);

            //Chiave composta per la tabella ponte
            modelBuilder.Entity<OrdineProdotto>()
                .HasKey(op => new {op.OrdineId, op.ProdottoId});

            //Relazioni
            modelBuilder.Entity<OrdineProdotto>()
                .HasOne(op => op.Ordine)
                .WithMany(o => o.OrdineProdotti)
                .HasForeignKey(op => op.OrdineId);

            modelBuilder.Entity<OrdineProdotto>()
                .HasOne(op => op.Prodotto)
                .WithMany()
                .HasForeignKey(op => op.ProdottoId);
        }
    }
}
