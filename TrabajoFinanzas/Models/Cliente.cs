using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; // directiva para acceder a las anotaciones de validación

namespace TrabajoFinanzas.Models;

public partial class Cliente
{
    public int IdUser { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El apellido es requerido")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "El DNI es requerido")]
    [MaxLength(8, ErrorMessage = "El DNI debe tener 8 dígitos")]
    public string Dni { get; set; } = null!;

    [Required(ErrorMessage = "El teléfono es requerido")]
    [MaxLength(9, ErrorMessage = "El teléfono debe tener 9 dígitos")]
    public string Telefono { get; set; } = null!;

    [Required(ErrorMessage = "El correo electrónico es requerido")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string CorreoElectronico { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es requerida")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
    public string Contrasena { get; set; } = null!;
}