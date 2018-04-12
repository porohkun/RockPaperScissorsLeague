using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FairPlayStrategy : AIStrategy
{
    public override Hand MakeMove(Hand opponentMove)
    {
        return new Hand((HandType)_rnd.Next(0, 3));
    }

    public override Hand MakeMove()
    {
        return new Hand((HandType)_rnd.Next(0, 3));
    }
}

