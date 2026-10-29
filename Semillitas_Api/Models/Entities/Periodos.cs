using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Periodos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public virtual ICollection<Cuentas> Cuentas { get; set; } = new List<Cuentas>();
}
