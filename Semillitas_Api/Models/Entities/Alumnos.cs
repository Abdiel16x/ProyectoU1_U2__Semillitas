using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Alumnos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public int IdTutor { get; set; }

    public virtual ICollection<Cuentas> Cuentas { get; set; } = new List<Cuentas>();

    public virtual Tutores IdTutorNavigation { get; set; } = null!;
}
