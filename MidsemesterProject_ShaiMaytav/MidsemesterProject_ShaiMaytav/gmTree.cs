using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    #region Enumerator
    public class GameObjectEnum : IEnumerator<GameObject>
    {
        public Stack<GameObject> stack = new Stack<GameObject>();
        GameObject _current;
        GameObject _root;
        public GameObject Current { get => _current; set => _current = value; }


        public GameObjectEnum(GameObject root)
        {
            Current = _root = root;
            stack.Push(Current);
        }

        public bool MoveNext()
        {
            if (!stack.Any())
            {
                return false;
            }

            Current = stack.Pop();

            for (int i = Current.children.Count - 1; i >= 0; i--)
            {
                stack.Push(Current.children[i]);
            }
            return true;
        }

        public void Reset()
        {
            stack.Clear();
            stack.Push(_root);
        }

        public void Dispose()
        {
            ;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
    #endregion

    #region Enumerable
    public class GameObjectTree : IEnumerable<GameObject>
    {
        public GameObject root;

        public GameObjectTree(GameObject obj)
        {
            root = obj;
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return new GameObjectEnum(root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
    #endregion
}
