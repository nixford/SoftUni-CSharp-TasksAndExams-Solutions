﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public interface IBaseHero
    {
        public string Name { get; }

        public int Power { get; }

        public string HeroType { get; set; }

        public string CastAbility();
    }
}
