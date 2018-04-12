using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GeraltStrategy : AIStrategy
{
    protected override Hand MakeMoveInternal(Hand opponentMove)
    {
        return MakeMove();
    }

    protected override Hand MakeMoveInternal()
    {
        if (_oppScore == 2 && _ownScore == 2)
            return Hand.Paper;
        else
            return new Hand((HandType)Random.Range(0, 3));
    }

    public override void LastRound(Hand oppHand)
    {
        base.LastRound(oppHand);
        if (_oppScore == 2 && _ownScore == 2)
            SendCustomMessage("axii");
    }
}

