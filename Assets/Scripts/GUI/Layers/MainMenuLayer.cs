using System.Collections;
using UnityEngine;

namespace Layers
{
    public class MainMenuLayer : LayerBase
    {
        public override VisibilityType Visibility { get { return VisibilityType.OnlyOnTop; } }

        public void OnChampionship()
        {
            LayersManager.FadeOut(0.5f, () =>
            {
                //LayersManager.Push<GameLayer>().Initialize();
                LayersManager.FadeIn(0.5f, () =>
                {
                });
            });
        }

        public void OnDuel()
        {
            //LayersManager.Push<GameLayer>();
        }

        public override void OnQuit()
        {
            LayersManager.FadeOut(0.5f, () => Application.Quit());
        }
    }
}
