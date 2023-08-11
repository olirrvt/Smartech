using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartecAPI.Models;

public partial class Carrinho
{
    public int IdDoCarrinho { get; set; }

    [JsonIgnore]
    public virtual ICollection<ItensCarrinho> ItensCarrinhos { get; set; } = new List<ItensCarrinho>();
}
