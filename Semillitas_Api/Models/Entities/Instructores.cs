using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Instructores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Talleres> Talleres { get; set; } = new List<Talleres>();
}
