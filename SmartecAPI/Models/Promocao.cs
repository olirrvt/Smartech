using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartecAPI.Models;

public partial class Promocao
{
    public int IdDaPromocao { get; set; }

    public string? NomeDaPromocao { get; set; }

    public string? Descricao { get; set; }

    [JsonIgnore]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
