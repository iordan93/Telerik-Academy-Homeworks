using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Army;

namespace Renderer
{
    public interface IRenderer
    {
        void CreateWorld(Map map);
        void EnquequeForRendering(object obj);
        void Update();
    }
}