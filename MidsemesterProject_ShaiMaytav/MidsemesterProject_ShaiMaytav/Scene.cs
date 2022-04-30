using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    public class Scene 
    {
        public GameObjectTree gameObjects;
        public GameObject root;

        public Scene()
        {
            root = new GameObject(this);
            gameObjects = new GameObjectTree(root);
            gameObjects.root.Name = "Root";
        }

        /// <summary>
        /// Prints all GameObjects in the scene
        /// </summary>
        public void PrintAllGos()
        {
            foreach (var item in gameObjects)
            {
                Console.WriteLine(item.Name);
            }
        }
        /// <summary>
        /// Searches for a GameObject in the scene by name and returns it if it exists.
        /// </summary>
        /// <param name="name">GameObject's name.</param>
        /// <returns>GameObject with the given name.</returns>
        public GameObject FindGO(string name)
        {
            foreach (var GO in gameObjects)
            {
                if (GO.Name == name)
                {
                    return GO;
                }
            }
            throw new Exception("GameObjectTree does not contain a GameOject named " + name);
        }

        /// <summary>
        /// Calls the Update() of all enabled GameObjects in the scene. 
        /// </summary>
        internal bool Update()
        {
            foreach (var item in gameObjects)
            {
                if (item.isEnabled)
                {
                    item.Upadte();
                }
            }
            return CheckColission();
        }

        bool CheckColission()
        {

            if (root.children.Count < 2)
                return true;

            GameObject g1 = root.children[0];
            GameObject g2 = root.children[1];

            return Physics.HandleColission(g1, g2);
        }
    }
}
