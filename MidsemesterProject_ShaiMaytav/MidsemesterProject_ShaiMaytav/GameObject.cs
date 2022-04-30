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
        public bool isEnabled = true;
        public List<GameObject> children = new List<GameObject>();

        public List<Component> components = new List<Component>();
        public Transform transform;
        Scene scene;

        public GameObject (Scene _scene)
        {
            transform = new Transform();
            scene = _scene;
            components.Add(transform);
        }

        public GameObject(Scene _scene, string name)
        {
            transform = new Transform();
            scene = _scene;
            components.Add(transform);
            Name = name;
        }

        /// <summary>
        /// Calls the Update() of all enabled children and Components contained in this parent GameObject. 
        /// </summary>
        public void Upadte()
        {
            foreach (var item in components)
            {
                if (item.isEnabled)
                {
                    item.Update();
                }
            }
            foreach (var item in children)
            {
                if (item.isEnabled)
                {
                    item.Upadte();
                }
            }
        }

        /// <summary>
        /// Triggers Disable() of all children of the GameObject and OnDisable() of all components.
        /// </summary>
        public void Disable()
        {
            foreach (var comp in components)
            {
                comp.OnDisable();
            }
            foreach (var item in children)
            {
                item.Disable();
            }
            isEnabled = false;
        }

        /// <summary>
        /// Triggers Enable() of all children of the GameObject and OnEnable() of all components.
        /// </summary>
        public void Enable()
        {
            foreach (var comp in components)
            {
                comp.OnEnable();
            }
            foreach (var item in children)
            {
                item.Enable();
            }
            isEnabled = true;
        }

        /// <summary>
        /// Triggers Destroy() of all children of the GameObject and OnDisable() of all components.
        /// </summary>
        public void Destroy()
        {
            foreach (var item in components)
            {
                item.OnDisable();
            }
            foreach (var item in children)
            {
                item.Destroy();
            }
        }

        /// <summary>
        /// Adds a Component to the GameObject
        /// </summary>
        /// <param name="comp"></param>
        public void AddComponent(Component comp)
        {
            components.Add(comp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comp"></param>
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

        /// <summary>
        /// Returns a component from the GameObjects components list with the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Component GetComonent(int index)
        {
            return components[index];
        }

        public Component GetComonent(Type type)
        {
            foreach(Component x in components)
            {
                if (x.GetType() == type)
                    return x;
            }
            
            return null;
        }
    }
}
