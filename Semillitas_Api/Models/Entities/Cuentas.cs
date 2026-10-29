using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Cuentas
{
    public int Id { get; set; }

    public int IdAlumno { get; set; }

    public int IdPeriodo { get; set; }

    public bool Pagado { get; set; }

    public DateOnly? FechaPago { get; set; }

    public virtual Alumnos IdAlumnoNavigation { get; set; } = null!;

    public virtual Periodos IdPeriodoNavigation { get; set; } = null!;

    public virtual ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();
}
