using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CheaterStrategy : AIStrategy
{
    [SerializeField]
    private float _victoryChance = 0.5f;

    public override Hand MakeMove(Hand opponentMove)
    {
        return new Hand((HandType)_rnd.Next(0, 3));
    }

    public override Hand MakeMove()
    {
        return new Hand((HandType)_rnd.Next(0, 3));
    }
}

