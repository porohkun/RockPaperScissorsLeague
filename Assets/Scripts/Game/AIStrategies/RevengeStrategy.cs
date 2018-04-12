using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RevengeStrategy : AIStrategy
{
    protected override Hand MakeMoveInternal(Hand opponentMove)
    {
        return MakeMove();
    }

    protected override Hand MakeMoveInternal()
    {
        if (_lastOppHand == null)
            return new Hand((HandType)Random.Range(0, 3));
        else if (_lastRoundResult < 0)
            return _lastOwnHand;
        else
            return _lastOppHand;
    }
}

