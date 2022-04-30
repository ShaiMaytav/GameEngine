using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace MidsemesterProject_ShaiMaytav
{
    class Game
    {
        public Scene ActiveScene;
        int GameCounter;
        System.Timers.Timer t = new System.Timers.Timer();

        float deltatime = 16.66f;
        public float DeltaTime { get => deltatime; set => deltatime = value; }
        public Game()
        {
            ActiveScene = new Scene();
            GameCounter = 0;
            t.Interval = deltatime;
        }
        public bool Run()
        {
            t.Elapsed += OnTimedEvent;
            t.Enabled = true;
            t.AutoReset = true;
            //do
            //{
                while (!Console.KeyAvailable)
                {
                    //Thread.Sleep(2); 
                   

                    
                }

            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
           return true;
        }
        bool LoadScene(Scene scene)
        {
            ActiveScene = scene;
            return true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!ActiveScene.Update())
            {
                t.Enabled = false;
            }
            ActiveScene.Update();
            Console.WriteLine("time:" + GameCounter);
            GameCounter++;      
        }

        
    }
}
