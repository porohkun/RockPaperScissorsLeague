using System;
using System.Collections;
using UnityEngine;

namespace Layers
{
    public class StartLayer : LayerBase
    {
        void Start()
        {
            LayersManager.Push<BackgroundLayer>();
            LayersManager.FadeIn(1f, () => LayersManager.Push<MainMenuLayer>());
        }

    }
}
