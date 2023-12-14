namespace erick_amorim.Models
{
    public class NotaDeVenda
    {
        public int NotaDeVendaId { get; set; }
        public DateTime Data { get; set; }
        public bool Tipo { get; set; }

        public StatusNotaDeVenda Status { get; set; }

        public virtual ICollection<Item>? Itens { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public int VendedorId { get; set; }
        public virtual Vendedor? Vendedor { get; set; }

        public virtual Transportadora? Transportadora { get; set; }
        public int TransportadoraId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
        public int PagamentoId { get; set; }

        public virtual ICollection<TipoPagamento>? TiposPagamento { get; set; }
    }
}
