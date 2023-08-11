using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartecAPI.Models;

public partial class ItensCarrinho
{
    public int Id { get; set; }

    public int IdDoCarrinho { get; set; }

    public int IdDoProduto { get; set; }

    public int Quantidade { get; set; }

    [JsonIgnore]
    public virtual Carrinho? IdDoCarrinhoNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Produto? IdDoProdutoNavigation { get; set; } = null!;
}
