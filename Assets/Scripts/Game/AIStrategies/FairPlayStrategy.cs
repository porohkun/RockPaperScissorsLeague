﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FairPlayStrategy : AIStrategy
{
    protected override Hand MakeMoveInternal(Hand opponentMove)
    {
        return MakeMove();
    }

    protected override Hand MakeMoveInternal()
    {
        return new Hand((HandType)Random.Range(0, 3));
    }
}

