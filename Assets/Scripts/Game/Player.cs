using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public Hand SelectedShape { get; set; }

    public Player (string name)
    {
        Name = name;
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
}

