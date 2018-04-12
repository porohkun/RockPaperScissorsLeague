using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Sprite Icon { get; private set; }
    public Hand SelectedShape { get; set; }
    public event Action<string> CustomMessage;

    public Player(string name)
    {
        Name = string.IsNullOrEmpty(name) ? "Player" : name;
        Description = "";
        SelectedShape = Hand.Rock;
    }

    public Hand MakeMoveAsFirst()
    {
        var shape = SelectedShape;
        SelectedShape = Hand.Rock;
        return shape;
    }

    public Hand MakeMoveAsSecond(Hand shape)
    {
        throw new NotImplementedException();
    }

    public void StartNewBattle()
    {

    }

    public void LastRoundResult(Hand oppHand)
    {
        
    }
}

