﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAp.Models;

public class Gastos
{
    [Key]
    public int GastoId { get; set; }
    [ForeignKey("CategoriaId")]
    public int CategoriaId { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Ingrese la Fecha.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Ingrese un Concepto")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string Concepto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese un Monto")]
    [Range(0.1, 20000000, ErrorMessage = "El rango del monto debe estar entre 0.1 y 20000000")]
    [RegularExpression(@"^[0-9]", ErrorMessage = "Solo se permiten números")]
    public float Monto { get; set; }
}