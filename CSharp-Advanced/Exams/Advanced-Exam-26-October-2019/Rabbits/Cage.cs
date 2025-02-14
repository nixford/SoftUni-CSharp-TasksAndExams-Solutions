﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private readonly List<Rabbit> data;

        private Cage()
        {
            this.data = new List<Rabbit>();
        }
        public Cage(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;            
        }        

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(rabbit);
            }            
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = this.data
                .FirstOrDefault(r => r.Name == name);

            if (rabbit != null)
            {
                this.data.Remove(rabbit);
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(r => r.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit firstRabbit = this.data.FirstOrDefault(r => r.Name == name);

            if (firstRabbit != null)
            {
                firstRabbit.Available = false;
            }           
            return firstRabbit;           
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbitArr = this.data
                .Where(r => r.Species == species)
                .ToArray();
            foreach (var rabbit in rabbitArr)
            {
                rabbit.Available = false;
            }

            return rabbitArr;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.data.Where(r => r.Available))
            {
                sb.AppendLine(rabbit.ToString());
            }           

            return sb.ToString().TrimEnd();                
        }
        
    }
}
