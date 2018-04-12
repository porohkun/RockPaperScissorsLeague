using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IPlayer
{
    Hand MakeMoveAsFirst();
    Hand MakeMoveAsSecond(Hand shape);
    void StartNewBattle();
}
