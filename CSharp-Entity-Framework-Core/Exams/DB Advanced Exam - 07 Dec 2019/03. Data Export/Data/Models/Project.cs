﻿using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; } 
        
        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }

    }
}
