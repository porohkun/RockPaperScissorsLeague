using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIStrategy : ScriptableObject
{
    public const string AssetsFolder = "Assets/Resources/AIStrategies";
    
    public virtual void Initialize()
    {

    }

    public virtual Hand MakeMove(Hand opponentMove)
    {
        throw new NotImplementedException();
    }

    public virtual Hand MakeMove()
    {
        throw new NotImplementedException();
    }
}

