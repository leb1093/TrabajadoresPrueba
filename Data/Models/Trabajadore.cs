using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajadoresPrueba.Data.Models
{
    public partial class Trabajadore
    {

        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdDistrito { get; set; }
        [NotMapped]
        public string? NombreDepartamento { get; set; }
        [NotMapped]
        public string? NombreProvincia { get; set; }
        [NotMapped]
        public string? NombreDistrito { get; set; }
        public virtual Departamento? IdDepartamentoNavigation { get; set; }
        public virtual Distrito? IdDistritoNavigation { get; set; }
        public virtual Provincium? IdProvinciaNavigation { get; set; }
    }
}
