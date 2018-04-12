using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BattleResultPanel : MonoBehaviour
{
    [SerializeField]
    private Text _player1Name;
    [SerializeField]
    private Text _player2Name;
    [SerializeField]
    private Text _result;

    public void BattleResult(Battle battle)
    {
        _player1Name.text = battle.Player1.Name;
        _player2Name.text = battle.Player2.Name;
        _result.text = string.Format("{0}:{1}", battle.Player1Score, battle.Player2Score);
    }
}
