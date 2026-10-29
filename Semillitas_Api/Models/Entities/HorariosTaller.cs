using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class HorariosTaller
{
    public int Id { get; set; }

    public int IdTaller { get; set; }

    public int DiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual Talleres IdTallerNavigation { get; set; } = null!;
}
