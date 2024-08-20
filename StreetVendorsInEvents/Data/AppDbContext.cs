using Microsoft.EntityFrameworkCore;
using StreetVendorsInEvents.Models;

namespace StreetVendorsInEvents.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Opcoes> Opcoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<OpcoesPedidos> OpcoesPedidos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BancoStreetVendors.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento um-para-muitos entre Endereco e Evento
            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Eventos) // Um Endereco tem muitos Eventos
                .WithOne(ev => ev.Endereco) // Cada Evento tem um Endereco
                .HasForeignKey(ev => ev.EnderecoId) // Chave estrangeira em Evento
                .OnDelete(DeleteBehavior.Restrict); // Define o comportamento de exclusão

            // Configuração do relacionamento um-para-muitos entre Loja e Opcoes
            modelBuilder.Entity<Loja>()
                .HasMany(l => l.Cardapio) // Uma Loja tem muitas Opcoes
                .WithOne(o => o.Loja) // Cada Opcao tem uma Loja
                .HasForeignKey(o => o.LojaId) // Chave estrangeira em Opcoes
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão em cascata

            // Configuração do relacionamento muitos-para-muitos entre Pedido e Opcoes através de OpcoesPedidos
            modelBuilder.Entity<OpcoesPedidos>()
                .HasKey(op => new { op.PedidoId, op.OpcaoId }); // Chave primária composta

            modelBuilder.Entity<OpcoesPedidos>()
                .HasOne(op => op.Pedido) // OpcoesPedidos tem um Pedido
                .WithMany(p => p.OpcaoPedidos) // Pedido tem muitas OpcoesPedidos
                .HasForeignKey(op => op.PedidoId); // Chave estrangeira em OpcoesPedidos

            modelBuilder.Entity<OpcoesPedidos>()
                .HasOne(op => op.Opcao) // OpcoesPedidos tem uma Opcao
                .WithMany(o => o.OpcaoPedidos) // Opcao tem muitas OpcoesPedidos
                .HasForeignKey(op => op.OpcaoId); // Chave estrangeira em OpcoesPedidos

            // Configuração do relacionamento um-para-muitos entre Evento e Loja
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Lojas) // Um Evento tem muitas Lojas
                .WithOne(l => l.Evento) // Cada Loja pertence a um Evento
                .HasForeignKey(l => l.EventoId); // Chave estrangeira em Loja
        }
    }
}
