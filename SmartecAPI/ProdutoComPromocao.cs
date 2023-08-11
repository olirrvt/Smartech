namespace SmartecAPI
{
    public class ProdutoComPromocao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }

        // Propriedades da Promoção
        public int? IdDaPromocao { get; set; }
        public string NomeDaPromocao { get; set; }
    }
}
