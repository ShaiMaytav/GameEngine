using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MidsemesterProject_ShaiMaytav
{
    #region Base Component
    public abstract class Component : IComponent
    {
        public bool isEnabled = true;

        public abstract void OnDisable();

        public abstract void OnEnable();

        public abstract void Start();

        public abstract void Update();
    }
    #endregion

    #region RigidBody
    public class RigidBody : Component
    {
        public bool UseGravity { get; set; }

        float _gravityScale = 1;
        public float GravityScale { get => _gravityScale; set => _gravityScale = value; }

        float force = 0;
        public float Force { get => force; set => force = value; }

        Vector2 dir = new Vector2(1, 0);
        public Vector2 Dir { get => dir; set => dir = value; }
        
        Transform trans;
        GameObject go;


        public RigidBody(GameObject _go)
        {
            trans = _go.transform;
            go = _go;
        }

        /// <summary>
        /// Apply's gravity using constant force.
        /// </summary>
        void ApplyGravity()
        {
            ApplyConstantForce(_gravityScale * Physics.Gravity, new Vector2(0, -1));
        }

        /// <summary>
        /// Moves the position to a given direction in a given force.
        /// </summary>
        /// <param name="force"></param>
        /// <param name="dir"></param>
        void ApplyConstantForce(float force, Vector2 dir)
        {
            float dirR = (float)Math.Sqrt((double)(dir.x * dir.x + dir.y * dir.y));
            Vector2 dirL = new Vector2(dir.x / dirR, dir.y / dirR);
            trans.ChangePos(force * dirL.x, force* dirL.y);
            //i know i could have used normalized here but forgot about it.
        }

        /// <summary>
        /// Sets isEnabled to false
        /// </summary>
        public override void OnDisable()
        {
            isEnabled = false;
        }

        /// <summary>
        /// Sets isEnabled to true
        /// </summary>
        public override void OnEnable()
        {
            isEnabled = true;
        }

        public override void Start()
        {
        }

        /// <summary>
        /// Triggers ApplyGravity if useGravity is true and ApplyConstantForce witha default force of 0.
        /// </summary>
        public override void Update()
        {
            if (UseGravity)
            {
                ApplyGravity();
            }
            ApplyConstantForce(Force, Dir);
            Console.WriteLine(go.Name + "'s position: " + trans.position);
        }
    }
    #endregion

    #region Transform
    public class Transform : Component
    {
        public Vector2 position = new Vector2();

        /// <summary>
        /// Changes current position to a given vector.
        /// </summary>
        /// <param name="changeTo">The new values you would like the position to have.</param>
        public void ChangePosTo(Vector2 changeTo)
        {
            position.x = changeTo.x;
            position.y = changeTo.y;
        }

        /// <summary>
        /// Changes current position's X and Y to two new values.
        /// </summary>
        /// <param name="X">The new X value you would like the position to have.</param>
        /// <param name="Y">The new Y value you would like the position to have.</param>
        public void ChangePosTo(float X, float Y)
        {
            position.x = X;
            position.y = Y;
        }

        /// <summary>
        /// Adds a given vector to the current value of position.
        /// </summary>
        /// <param name="vectorToAdd"></param>
        public void ChangePos(Vector2 vectorToAdd)
        {
            position.x += vectorToAdd.x;
            position.y += vectorToAdd.y;
        }

        /// <summary>
        /// Adds two Values to current position's X and Y.
        /// </summary>
        /// <param name="X">The X value you would like to add to the current X</param>
        /// <param name="Y">The Y value you would like to add to the current Y</param>
        public void ChangePos(float X, float Y)
        {
            position.x += X;
            position.y += Y;
        }

        /// <summary>
        /// Sets is Enabled to false
        /// </summary>
        public override void OnDisable()
        {
            isEnabled = false;
        }

        /// <summary>
        /// Sets is Enabled to true
        /// </summary>
        public override void OnEnable()
        {
            isEnabled = true;
        }

        public override void Start()
        {
           ;
        }

        public override void Update()
        {
        }
    }
    #endregion

    #region BoxCollider
    public class BoxCollider : Component
    {
        static Vector2 pos;
        GameObject go;

        static readonly Vector2 Size = new Vector2(1 , 1);

        public float bottomEdge   ;
        public float topEdge      ;
        public float leftEdge     ;
        public float rightEdge    ;

        public BoxCollider (GameObject go)
        {
            this.go = go;
            pos = new Vector2(((Transform)go.components[0]).position);

            bottomEdge = pos.y + Size.y;
            topEdge = pos.y - Size.y;
            leftEdge = pos.x - Size.x;
            rightEdge = pos.x + Size.x;
        }

        /// <summary>
        /// Sets isEnabled to false
        /// </summary>
        public override void OnDisable()
        {
            isEnabled = false;        
        }

        /// <summary>
        /// Sets isEnabled to true
        /// </summary>
        public override void OnEnable()
        {
            isEnabled = true;        
        }

        public override void Start()
        {
            ;
        }

        public override void Update()
        {
            bottomEdge = go.transform.position.y + Size.y;
            topEdge = go.transform.position.y - Size.y;
            leftEdge = go.transform.position.x - Size.x;
            rightEdge = go.transform.position.x + Size.x;
        }
    }
    #endregion
}
