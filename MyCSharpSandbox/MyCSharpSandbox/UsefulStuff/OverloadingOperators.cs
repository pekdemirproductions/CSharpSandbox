using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpSandbox
{
    class OverloadingOperators
    {
        public static void Start()
        {
            Robot T800 = new Robot() { attackpower = 1000, agility = 300, name = "Arnold T800" };
            Robot Marvin = new Robot() { attackpower = 42, agility = 100, name = "Marvin" };
            Robot ClusterBot = T800 + Marvin;

            Console.WriteLine("ClusterBot Agility: "+ ClusterBot.agility);
            Console.WriteLine("ClusterBot Attack Power: " + ClusterBot.attackpower);
            Console.WriteLine("ClusterBot Name: " + ClusterBot.name);
        }

        public class Robot
        {
            public double attackpower;
            public double agility;
            public string name;

            // Hier wird die Addition zweier Roboter definiert. Klingt komisch ... ist aber so. :)
            public static Robot operator+ (Robot a, Robot b)
            {
                Robot tempRobot = new Robot();
                // Hier wird entschieden, was addiert wird:
                tempRobot.attackpower = a.attackpower + b.attackpower;

                // Werte können dabei auch kleiner werden:
                tempRobot.agility = (a.agility + b.agility / 2) * 0.7;  

                // Strings dürfen auch umgemodelt werden ...
                tempRobot.name = string.Format("RoboCluster[{0}][{1}]", a.name, b.name);

                return tempRobot;

                // Das Ganze geht auch mit <, > und auch logischen Operatoren ( and, or ...)
            }
        }
    }
}
