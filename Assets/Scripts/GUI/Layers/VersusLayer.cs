using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Layers
{
    public class VersusLayer : LayerBase
    {
        [SerializeField]
        private Image _playerIcon;
        [SerializeField]
        private Image _aiPlayerIcon;
        [SerializeField]
        private Animator _animator;

        public void BeginVersus(AIPlayerModel aIPlayer)
        {
            _aiPlayerIcon.sprite = aIPlayer.Icon;
            _animator.SetBool("Versus", true);


            StartCoroutine(VersusRoutine(() => LayersManager.Push<BattleLayer>().Begin(aIPlayer)));
        }

        public void BeginVersus(Battle currentPlayerBattle)
        {
            _aiPlayerIcon.sprite = currentPlayerBattle.Player2.Icon;
            _animator.SetBool("Versus", true);


            StartCoroutine(VersusRoutine(() => LayersManager.Push<BattleLayer>().Begin(currentPlayerBattle)));
        }

        private IEnumerator VersusRoutine(Action callback)
        {
            yield return new WaitForSeconds(1.25f);

            LayersManager.FadeOut(0.25f, () =>
            {
                _animator.SetBool("Versus", false);
                if (callback != null)
                    callback();
                LayersManager.Pop(this);
                LayersManager.FadeIn(0.25f, null);
            });
        }
    }
}
