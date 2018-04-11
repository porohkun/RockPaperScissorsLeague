using System;
using System.Collections;
using UnityEngine;

namespace Layers
{
    public class BackgroundLayer : LayerBase
    {
        public override VisibilityType Visibility { get { return VisibilityType.NeverHiding; } }
    }
}
