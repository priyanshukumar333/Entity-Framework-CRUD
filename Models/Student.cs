using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrame.Models;

public partial class Student
{
  
    public int Id { get; set; }
    [Required]
    [DisplayName("Roll Number")]

    public int? Roll { get; set; }
    [Required]
    [DisplayName("Student Name")]
    public string? StuName { get; set; }
    [Required]
    [DisplayName("Gender")]
    public string? StuGender { get; set; }
    [Required]
    [DisplayName("Date of Birth")]
    public string? StuDob { get; set; }
    [Required]
    [Length(10,10)]
    [DisplayName("Phone")]
    public string? StuPhone { get; set; }
    [Required]
    [DisplayName("Book")]
    public string? StuBook { get; set; }
}
