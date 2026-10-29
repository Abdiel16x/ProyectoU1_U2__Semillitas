using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Tutores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Alumnos> Alumnos { get; set; } = new List<Alumnos>();
}
