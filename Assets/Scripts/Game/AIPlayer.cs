using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIPlayer : IPlayer
{
    public AIStrategy Strategy;

    public AIPlayer(AIStrategy strategy)
    {
        Strategy = GameObject.Instantiate(strategy);
    }

    public Hand MakeMoveAsFirst()
    {
        return Strategy.MakeMove();
    }
    
    public Hand MakeMoveAsSecond(Hand shape)
    {
        return Strategy.MakeMove(shape);
    }

    public void StartNewBattle()
    {
        Strategy.Initialize();
    }
}

