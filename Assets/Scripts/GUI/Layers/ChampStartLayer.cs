using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Layers
{
    public class ChampStartLayer : LayerBase
    {
        [SerializeField]
        private InputField _playerName;

        internal override void OnFloatUp()
        {
            base.OnFloatUp();
            _playerName.text = "";
        }

        public void OnOk()
        {
            LayersManager.FadeOut(0.25f, () =>
            {
                LayersManager.Pop();
                LayersManager.Push<ChampLayer>().NewPlayer(_playerName.text);
                LayersManager.FadeIn(0.25f, null);
            });
        }

        public override void OnQuit()
        {
            LayersManager.FadeOut(0.25f, () =>
            {
                LayersManager.PopTill<MainMenuLayer>();
                LayersManager.FadeIn(0.25f, null);
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnQuit();
            }
        }
    }
}
