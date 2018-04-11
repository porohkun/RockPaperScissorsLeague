using System.Collections;
using UnityEngine;

namespace Layers
{
    public class MainMenuLayer : LayerBase
    {
        public override HidingType Hiding { get { return HidingType.HideAll; } }

        public void OnPlay()
        {
            LayersManager.FadeOut(0.5f, () =>
            {
                //LayersManager.Push<GameLayer>().Initialize();
                LayersManager.FadeIn(0.5f, () =>
                {
                });
            });
        }

        public void OnTutorial()
        {
            //LayersManager.Push<GameLayer>();
        }
        
        public void OnFeedback()
        {
            //LayersManager.Push<FeedbackLayer>();
        }
    }
}
