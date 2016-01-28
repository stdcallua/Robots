using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;

namespace std
{
        public class Falcon: Robot
        {
            public override void Run()
            {
                // -- Initialization of the robot --

                // Here we turn the robot to point upwards, and move the gun 90 degrees
                TurnLeft(Heading - 90);
                TurnGunRight(90);

                // Infinite loop making sure this robot runs till the end of the battle round
                while (true)
                {
                    // -- Commands that are repeated forever --

                    // Move our robot 5000 pixels ahead
                    Ahead(100);

                    // Turn the robot 90 degrees
                    TurnRight(90);

                    // Our robot will move along the borders of the battle field
                    // by repeating the above two statements.
                }
            }

            // Robot event handler, when the robot sees another robot
            public override void OnScannedRobot(ScannedRobotEvent e)
            {
                // We fire the gun with bullet power = 1
                Fire(Rules.MAX_BULLET_POWER);
            }

    }
}
