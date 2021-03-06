﻿using System.Collections;
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
                LayersManager.Push<ChampStartLayer>();
                LayersManager.FadeIn(0.5f, () =>
                {
                });
            });
        }

        public void OnDuel()
        {
            LayersManager.FadeOut(0.5f, () =>
            {
                LayersManager.Push<DuelStartLayer>();
                LayersManager.FadeIn(0.5f, null);
            });
        }

        public override void OnQuit()
        {
            LayersManager.FadeOut(0.5f, () => Application.Quit());
        }
    }
}
