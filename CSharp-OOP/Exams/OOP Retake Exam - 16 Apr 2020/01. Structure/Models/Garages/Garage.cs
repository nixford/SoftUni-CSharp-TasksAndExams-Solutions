﻿using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {        
        private const int DefaultCapasity = 10;
        private readonly Dictionary<string, IRobot> robots;
       

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public int Capacity => DefaultCapasity;

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = this.Robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robot.Name);
        }
    }
}
