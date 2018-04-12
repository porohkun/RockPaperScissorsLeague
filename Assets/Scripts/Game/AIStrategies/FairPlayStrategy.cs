using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FairPlayStrategy : AIStrategy
{
    public override Hand MakeMove(Hand opponentMove)
    {
        return new Hand((HandType)Random.Range(0, 3));
    }

    public override Hand MakeMove()
    {
        return new Hand((HandType)Random.Range(0, 3));
    }
}

