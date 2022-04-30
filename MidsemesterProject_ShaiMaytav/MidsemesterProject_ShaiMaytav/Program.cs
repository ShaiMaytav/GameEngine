// ---- Advanced C# (Dor Ben Dor) ----
//             Shai Maytav
//             20/10/2021
// -----------------------------------
//i have some bugs that would have been fixed if i had a bit more time.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            GameObject go1 = new GameObject(game.ActiveScene, "go1");
            GameObject go2 = new GameObject(game.ActiveScene, "go2");
            game.ActiveScene.root.children.Add(go1);
            game.ActiveScene.root.children.Add(go2);

            RigidBody r1 = new RigidBody(go1);
            RigidBody r2 = new RigidBody(go2);

            BoxCollider b1 = new BoxCollider(go1);
            BoxCollider b2 = new BoxCollider(go2);

            go1.AddComponent(r1);
            go1.AddComponent(b1);
            go2.AddComponent(r2);
            go2.AddComponent(b2);

            go1.transform.ChangePosTo(10, 0);
            go2.transform.ChangePosTo(0, 0);

            r2.Force = 1;

            Console.WriteLine("Game Object 1 starting position: " + go1.transform.position);
            Console.WriteLine("Game Object 2 starting position: " + go2.transform.position);

            game.Run();
        }
    }
}
