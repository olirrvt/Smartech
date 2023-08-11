using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartecAPI.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public string Categoria { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int? IdDaPromocao { get; set; }

    [JsonIgnore]
    public virtual Promocao? IdDaPromocaoNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<ItensCarrinho> ItensCarrinhos { get; set; } = new List<ItensCarrinho>();
}
