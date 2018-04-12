using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Layers
{
    public class ChampLayer : LayerBase
    {
        [SerializeField]
        private Transform _opponentsList;
        [SerializeField]
        private ChampPlayerPanel _playerPanelPrefab;
        [SerializeField]
        private Transform _resultsList;
        [SerializeField]
        private BattleResultPanel _resultsPanelPrefab;
        [SerializeField]
        private Text _nextOpponent;

        private Tournament _tour;
        private Battle _currentPlayerBattle;

        public void NewPlayer(string name)
        {
            _tour = new Tournament();
            foreach (var model in Resources.FindObjectsOfTypeAll<AIPlayerModel>())
                _tour.AddPlayer(new AIPlayer(model));
            _tour.RunLaps(100);
            _tour.AddPlayer(new Player(name));

            ShowTournament();
        }

        internal override void OnFloatUp()
        {
            if (_tour != null)
            {
                _tour.ContinueLap();
                ShowTournament();
            }
        }

        private void ShowTournament()
        {
            _currentPlayerBattle = _tour.RunLap();
            _nextOpponent.text = _currentPlayerBattle.Player2.Name;

            int i = 0;
            foreach (var player in _tour.Players)
            {
                ChampPlayerPanel playerPanel;
                if (_opponentsList.childCount > i)
                    playerPanel = _opponentsList.GetChild(i).GetComponent<ChampPlayerPanel>();
                else
                {
                    playerPanel = Instantiate(_playerPanelPrefab);
                    playerPanel.transform.SetParent(_opponentsList);
                    playerPanel.transform.localScale = Vector3.one;
                }
                playerPanel.ShowPlayer(player, i + 1);
                i++;
            }

            i = 0;
            foreach (var battle in _tour.LastBattles)
            {
                BattleResultPanel resultsPanel;
                if (_resultsList.childCount > i)
                    resultsPanel = _resultsList.GetChild(i).GetComponent<BattleResultPanel>();
                else
                {
                    resultsPanel = Instantiate(_resultsPanelPrefab);
                    resultsPanel.transform.SetParent(_resultsList);
                    resultsPanel.transform.localScale = Vector3.one;
                }
                resultsPanel.BattleResult(battle);
                i++;
            }
        }

        public void OnFight()
        {
            LayersManager.FadeOut(0.25f, () =>
            {
                LayersManager.Push<VersusLayer>().BeginVersus(_currentPlayerBattle);
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

        public override void OnQuit()
        {
            LayersManager.FadeOut(0.25f, () =>
            {
                _tour = null;
                LayersManager.PopTill<MainMenuLayer>();
                LayersManager.FadeIn(0.25f, null);
            });
        }

    }
}
