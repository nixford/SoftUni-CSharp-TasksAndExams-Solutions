﻿using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            
            base.DoService(robot, procedureTime);
            if (robot.IsChipped == true)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.IsChipped = true;
            robot.Happiness -= 5;
            this.Robots.Add(robot);
        }        
    }
}
