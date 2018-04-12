using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.Tween;

namespace Layers
{
    public class BattleLayer : LayerBase
    {
        [SerializeField]
        private HandShaker _playerHand;
        [SerializeField]
        private HandShaker _aiPlayerHand;
        [SerializeField]
        private Image _aiPlayerIcon;
        [SerializeField]
        private Text _playerName;
        [SerializeField]
        private Text _aiPlayerName;
        [SerializeField]
        private Text _playerScores;
        [SerializeField]
        private Text _aiPlayerScores;
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private Text _roundText;
        [SerializeField]
        private Text _countdown;
        [SerializeField]
        private GameObject _exitButton;

        private AIPlayerModel _aiPlayer;
        private Battle _battle;
        private Player _player;

        private void Awake()
        {
            _playerHand.ShakeEnded += _playerHand_ShakeEnded;
            _playerHand.WinEnded += _playerHand_WinEnded;
            _aiPlayerHand.WinEnded += _playerHand_WinEnded;
        }

        public void Begin(AIPlayerModel aiplayer)
        {
            _player = new Player("Player");
            _battle = new Battle(_player, new AIPlayer(aiplayer.Strategy));
            _aiPlayer = aiplayer;
            _aiPlayerIcon.sprite = aiplayer.Icon;
            _aiPlayerName.text = aiplayer.Name;
            _playerName.text = "Player";
            _roundText.text = "1/5";
            _playerHand.SetHandShape(Hand.Rock);
            _aiPlayerHand.SetHandShape(Hand.Rock);

            Lock();

            var rt = (RectTransform)_countdown.transform;
            _countdown.gameObject.SetActive(true);
            _countdown.text = "3";
            TweenFactory.Tween(_countdown, Vector2.zero, Vector2.up * 100f, 0.7f, TweenScaleFunctions.CubicEaseOut, (p) => rt.anchoredPosition = p.CurrentValue, (c1) =>
             {
                 rt.anchoredPosition = Vector2.zero;
                 _countdown.text = "2";
                 TweenFactory.Tween(_countdown, Vector2.zero, Vector2.up * 100f, 0.7f, TweenScaleFunctions.CubicEaseOut, (p) => rt.anchoredPosition = p.CurrentValue, (c2) =>
                 {
                     rt.anchoredPosition = Vector2.zero;
                     _countdown.text = "1";
                     TweenFactory.Tween(_countdown, Vector2.zero, Vector2.up * 100f, 0.7f, TweenScaleFunctions.CubicEaseOut, (p) => rt.anchoredPosition = p.CurrentValue, (c3) =>
                     {
                         rt.anchoredPosition = Vector2.zero;
                         _countdown.text = "FIGHT!";
                         TweenFactory.Tween(_countdown, Vector2.zero, Vector2.up * 100f, 0.7f, TweenScaleFunctions.CubicEaseOut, (p) => rt.anchoredPosition = p.CurrentValue, (c4) =>
                         {
                             rt.anchoredPosition = Vector2.zero;
                             _countdown.gameObject.SetActive(false);
                             NextRound();
                         });
                     });
                 });
             });
        }

        private void NextRound()
        {
            if (!_battle.WinnerIsDeterminated)
            {
                Unlock();

                _roundText.text = _battle.Round + "/5";

                _playerHand.SetHandShape(Hand.Rock);
                _aiPlayerHand.SetHandShape(Hand.Rock);
                _playerHand.StartShake();
                _aiPlayerHand.StartShake();
            }
            else
            {
                var rt = (RectTransform)_countdown.transform;
                _countdown.gameObject.SetActive(true);
                _countdown.text = _battle.Winner == 1 ? "YOU WIN!" : (_battle.Winner == 2 ? "YOU LOSE!" : "DEAD HEAT! O_O");
                TweenFactory.Tween(_countdown, Vector3.one * 0.3f, Vector3.one * 0.6f, 1.2f, TweenScaleFunctions.CubicEaseOut, (p) => rt.localScale = p.CurrentValue, (c) =>
                    {
                        _exitButton.SetActive(true);
                    });
            }
        }

        private void _playerHand_ShakeEnded()
        {
            Lock();

            _battle.MakeRound();

            _playerScores.text = _battle.Player1Score.ToString();
            _aiPlayerScores.text = _battle.Player2Score.ToString();

            _playerHand.SetHandShape(_battle.Player1Shape);
            _aiPlayerHand.SetHandShape(_battle.Player2Shape);

            switch (_battle.RoundWinner)
            {
                case 0: TweenFactory.Tween(this, 0f, 1f, 0.4f, TweenScaleFunctions.Linear, null, (c) => NextRound()); break;
                case 1: _playerHand.StartWin(); break;
                case 2: _aiPlayerHand.StartWin(); break;
            }
        }
        
        private void _playerHand_WinEnded()
        {
            NextRound();
        }

        public void OnRockSelected()
        {
            _player.SelectedShape = Hand.Rock;
        }

        public void OnPaperSelected()
        {
            _player.SelectedShape = Hand.Paper;
        }

        public void OnScissorsSelected()
        {
            _player.SelectedShape = Hand.Scissors;
        }

        private void Lock()
        {
            _canvasGroup.interactable = false;
        }

        private void Unlock()
        {
            _canvasGroup.interactable = true;
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
                _exitButton.SetActive(false);
                ((RectTransform)_countdown.transform).localScale = Vector2.one;
                _countdown.gameObject.SetActive(false);
                LayersManager.PopTill<MainMenuLayer>();
                LayersManager.FadeIn(0.25f, null);
            });
        }
    }
}
