using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TuTor_cho_nguoi_than.DomainClass;

[Table("Lop")]
public partial class Lop
{
    [Key]
    [Column("idLop")]
    public Guid IdLop { get; set; }

    [Column("tenLop")]
    [StringLength(50)]
    public string? TenLop { get; set; }

    [InverseProperty("IdLopNavigation")]
    public virtual ICollection<HocSinh> HocSinhs { get; set; } = new List<HocSinh>();
}
