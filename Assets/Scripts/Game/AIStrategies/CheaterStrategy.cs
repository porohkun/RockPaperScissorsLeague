
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CheaterStrategy : AIStrategy
{
    [SerializeField]
    private float _victoryChance = 0.5f;

    private bool _win;
    private int _ownScore;
    private int _oppScore;

    public override void Initialize()
    {
        _win = Random.Range(0f, 1f) < _victoryChance;
    }

    public override Hand MakeMove(Hand opponentMove)
    {
        for (int i = 0; i < 100;i++) 
        Debug.Log(Random.Range(0, 2));
        Hand ownMove;
        if ((_ownScore == 0 && _oppScore == 0) ||
            (_win && _ownScore > _oppScore) ||
            (!_win && _ownScore < _oppScore))
            ownMove = MakeMove();
        else if (Random.Range(0, 2) == 0)
            ownMove = opponentMove;
        else if (_win)
            ownMove = ++opponentMove;
        else
            ownMove = --opponentMove;

        if (ownMove > opponentMove)
            _ownScore++;
        else if (ownMove < opponentMove)
            _oppScore++;

        return ownMove;
    }

    public override Hand MakeMove()
    {
        return new Hand((HandType)Random.Range(0, 3));
    }
}

