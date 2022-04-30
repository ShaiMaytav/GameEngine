using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    static class Physics
    {
        public static float Gravity { get; set; } = 9.8f;

        public static bool IsColliding(GameObject goA, GameObject goB)
        {
            var goAC = goA.components.OfType<BoxCollider>();
            var goBC = goB.components.OfType<BoxCollider>();
            BoxCollider boxA;
            BoxCollider boxB;

            if (goAC.Any() && goBC.Any())
            {
                boxA = goAC.First();
                boxB = goBC.First();

                return boxA.leftEdge <= boxB.rightEdge &&
                       boxA.rightEdge >= boxB.leftEdge &&
                       boxA.bottomEdge >= boxB.topEdge &&
                       boxA.topEdge <= boxB.bottomEdge  ;

            }
            return false;
        }

        public static bool HandleColission(GameObject goA, GameObject goB)
        {
            if (IsColliding(goA, goB))
            {
                goA.components.OfType<RigidBody>().First().Force = 0;
                goB.components.OfType<RigidBody>().First().Force = 0;
                Console.WriteLine("A collision has accured between " + goA.Name + " and " + goB.Name);
                Console.WriteLine(goA.Name + " collided with " + goB.Name + " and stopped moving");
                return false;
            }
            return true;
        }
    }
}
