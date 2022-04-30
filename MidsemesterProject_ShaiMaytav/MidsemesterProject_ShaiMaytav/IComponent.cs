using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidsemesterProject_ShaiMaytav
{
    interface IComponent
    {
        void Start();

        void OnEnable();

        void OnDisable();

        void Update();
    }
}
