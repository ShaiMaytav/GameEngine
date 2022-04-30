using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MidsemesterProject_ShaiMaytav
{
    class Game
    {
        Scene ActiveScene;
        int GameCounter;
        Timer t;
        float DeltaTime { get; set; }
        public Game()
        {
            ActiveScene = new Scene();
            GameCounter = 0;
            t.Interval = 5;
            
            //LoadScene(scene);
        }
        bool Run()
        {
            while(true)
            {

                t.Elapsed += OnTimedEvent;
         
                t.Enabled = true;
            }
            return true;
        }
        bool LoadScene(Scene scene)
        {
            ActiveScene = scene;
            return true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            ActiveScene.updateTick(GameCounter);
            GameCounter++;
            
        }

      
    }
}
