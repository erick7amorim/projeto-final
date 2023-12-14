namespace erick_amorim.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public double Preco { get; set; }
        public int Percentual { get; set; }
        public int Quantidade { get; set; }

        public virtual ICollection<Produto>? Produtos { get; set; }

        public int NotaDeVendaId { get; set; }
        public virtual NotaDeVenda? NotaDeVenda { get; set; }
    }
}
