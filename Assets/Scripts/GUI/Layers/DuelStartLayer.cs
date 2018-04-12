using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Layers
{
    public class DuelStartLayer : LayerBase
    {
        public override VisibilityType Visibility { get { return VisibilityType.OnlyOnTop; } }
        
        private AIPlayerModel[] _aiPlayers;

        [SerializeField]
        private Transform _opponentsList;

        [SerializeField]
        private AIPlayerButton _buttonPrefab;

        private void Start()
        {
            _aiPlayers = Resources.FindObjectsOfTypeAll<AIPlayerModel>();
            foreach (var player in _aiPlayers)
                if (player != null)
                {
                    var button = Instantiate(_buttonPrefab);
                    button.Clicked += Button_Clicked;
                    button.ShowPlayer(player);
                    button.transform.SetParent(_opponentsList);
                    button.transform.localScale = Vector3.one;
                }
        }

        private void Button_Clicked(AIPlayerModel aiplayer)
        {
            LayersManager.FadeOut(0.25f, () =>
            {
                LayersManager.Push<VersusLayer>().BeginVersus(aiplayer);
                LayersManager.FadeIn(0.25f, null);
            });
        }
    }
}
