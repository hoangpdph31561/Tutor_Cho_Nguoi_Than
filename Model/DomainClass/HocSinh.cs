using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TuTor_cho_nguoi_than.DomainClass;

[Table("HocSinh")]
[Index("MaHocSinh", Name = "UQ__HocSinh__B9EB1975F43B2DD7", IsUnique = true)]
public partial class HocSinh
{
    [Key]
    [Column("idHocSinh")]
    public Guid IdHocSinh { get; set; }

    [Column("maHocSinh")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaHocSinh { get; set; } = null!;

    [Column("tenHocSinh")]
    [StringLength(50)]
    public string? TenHocSinh { get; set; }

    [Column("email")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("soDienThoai")]
    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai { get; set; }

    [Column("diaChi")]
    [StringLength(50)]
    public string? DiaChi { get; set; }

    [Column("gioiTinh")]
    public bool? GioiTinh { get; set; }

    [Column("idLop")]
    public Guid IdLop { get; set; }

    [ForeignKey("IdLop")]
    [InverseProperty("HocSinhs")]
    public virtual Lop IdLopNavigation { get; set; } = null!;
}
