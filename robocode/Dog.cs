using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;

namespace std
{
    public class Dog: AdvancedRobot
    {
        public override void Run()
        {
            while (true)
            {
                Ahead(100);
                TurnGunRight(360);
                Ahead(-100);
                TurnGunRight(360);
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            // We fire the gun with bullet power = 1
            Fire(Rules.MIN_BULLET_POWER);
            TurnGunRight(10);
            TurnGunRight(-10);
        }
    }
}
