using CivGame.ECS.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivGame.ECS
{
    interface IComponentFactory
    {
        IComponent Create(IComponentBuilder componentBuilder);
    }

    interface IComponentBuilder
    {
        ComponentBuilderType Type { get; }
    }

    enum ComponentBuilderType
    {
        MotionComponent = 1,
        InputComponent = 2,
        DrawingComponent = 3
    }
}
