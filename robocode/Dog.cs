using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using std.math;
using Robocode;

namespace std
{
    public class Dog: AdvancedRobot
    {
        public Dog()
        {
           
        }

        public override void Run()
        {
            while (true)
            {
                SetAhead(100);
                SetTurnGunRight(90);
                SetTurnLeft(180);
                //TurnGunRight(360);
                Execute();
            }
        }
        //private DebugControler _debugControler;

        int targetX = int.MinValue;
        int targetY = int.MinValue;

        private double radtodeg(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private double degtorad(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            // We fire the gun with bullet power = 1
            Fire(Rules.MAX_BULLET_POWER);
            double angle = degtorad(Heading);
            // Calculate the coordinates of the robot
            targetX = (int)(X + Math.Sin(angle) * e.Distance);
            targetY = (int)(Y + Math.Cos(angle) * e.Distance);
        }

        public override void OnPaint(IGraphics g)
        {
            // Draw a line from our robot to the scanned robot
            g.DrawLine(new Pen(Color.Red),  targetX, targetY, (int)X, (int)Y);

            // Draw a filled square on top of the scanned robot that covers it
            g.DrawRectangle(new Pen(Color.Red), targetX - 20, targetY - 20, 40, 40);
        }
    }
}
