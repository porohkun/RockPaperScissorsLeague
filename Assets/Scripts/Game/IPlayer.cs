using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IPlayer
{
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
    event Action<string> CustomMessage;

    Hand MakeMoveAsFirst();
    Hand MakeMoveAsSecond(Hand shape);
    void StartNewBattle();
    void LastRoundResult(Hand oppHand);
}
