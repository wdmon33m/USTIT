﻿using System.ComponentModel.DataAnnotations;

namespace USTITWEB.Areas.BasicData.Models.UpdateDto
{
    public class CourseUpdateDto
    {
        [Required]
        public string CourseCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string CourseTitle { get; set; }
        public string? Notes { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
