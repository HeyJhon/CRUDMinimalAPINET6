using System;
using System.Collections.Generic;

namespace RMF.School.Entities;

public partial class Alumno
{
    public long NumeroControl { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }
}
