﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCards = new HashSet<UserCard>();
        }


        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        // [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
