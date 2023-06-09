﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetProject_4.Domain.Models
{
    [Index("UserId", Name = "IX_UserProjects_UserId")]
    public partial class UserProject
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string repository { get; set; }
        public string page { get; set; }
        public string image { get; set; }
        [Required]
        public string date { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserProjects")]
        public virtual AspNetUser User { get; set; }
    }
}