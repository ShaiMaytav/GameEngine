using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    public class GameObject
    {
        public string Name { get; set; }
        bool isEnabled = true;
        public List<GameObject> children = new List<GameObject>();

        public List<Component> components = new List<Component>();
        Scene scene;

        public GameObject (Scene _scene)
        {
            scene = _scene;
            _scene.AddGO(this);
            components.Add(new Transform());
        }

        public GameObject(Scene _scene, string name)
        {
            scene = _scene;
            _scene.AddGO(this);
            components.Add(new Transform());
            Name = name;
        }

        public void Disable()
        {
            foreach (var comp in components)
            {
                comp.OnDisable();
            }
            isEnabled = false;
            //disables gameobject
        }

        public void Enable()
        {
            foreach (var comp in components)
            {
                comp.OnEnable();
            }
            isEnabled = true;
            //enables gameobject
        }

        public void Destroy()
        {
            //destroys gameobject, trigers onDisable()
        }

        public void AddComponent(Component comp)
        {
            components.Add(comp);
        }

        public void RemoveComponent(Component comp)
        {
            if (components.Contains(comp))
            {
                components.Remove(comp);
            }
            else
            {
                Console.WriteLine("GameObject doesn't have the component: " + comp );
            }
        }

        public Component GetComonent(int index)
        {
            return components[index];
        }
    }
}
