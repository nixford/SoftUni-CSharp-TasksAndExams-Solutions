﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Models
{
    public class Album
    {
        public Album()
        {
            this.AlbumId = Guid.NewGuid().ToString();
            this.Tracks = new HashSet<Track>();
        }

        public string AlbumId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}