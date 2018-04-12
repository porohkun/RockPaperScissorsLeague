using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIPlayer : IPlayer
{
    public string Name { get { return Model.name; } }
    public string Description { get { return Model.Description; } }
    public Sprite Icon { get { return Model.Icon; } }
    public AIStrategy Strategy { get; private set; }
    public AIPlayerModel Model { get; private set; }
    public event Action<string> CustomMessage;

    public AIPlayer(AIPlayerModel player)
    {
        Model = player;
        Strategy = GameObject.Instantiate(player.Strategy);
        Strategy.CustomMessage += (m) => { if (CustomMessage != null) CustomMessage(m); };
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

    public void LastRoundResult(Hand oppHand)
    {
        Strategy.LastRound(oppHand);
    }
}

