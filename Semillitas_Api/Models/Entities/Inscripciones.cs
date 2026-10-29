using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Inscripciones
{
    public int Id { get; set; }

    public int IdCuenta { get; set; }

    public int IdTaller { get; set; }

    public virtual Cuentas IdCuentaNavigation { get; set; } = null!;

    public virtual Talleres IdTallerNavigation { get; set; } = null!;
}
