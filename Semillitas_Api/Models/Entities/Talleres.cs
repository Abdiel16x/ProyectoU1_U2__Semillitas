using System;
using System.Collections.Generic;

namespace Semillitas_Api.Models.Entities;

public partial class Talleres
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdInstructor { get; set; }

    public int IdCategoria { get; set; }

    public int CupoMaximo { get; set; }

    public decimal CostoMensual { get; set; }

    public virtual ICollection<HorariosTaller> HorariosTaller { get; set; } = new List<HorariosTaller>();

    public virtual Categorias IdCategoriaNavigation { get; set; } = null!;

    public virtual Instructores IdInstructorNavigation { get; set; } = null!;

    public virtual ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();
}
