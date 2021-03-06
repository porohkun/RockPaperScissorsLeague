﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Battle
{
    const int _summaryScore = 5;

    public IPlayer Player1 { get; private set; }
    public IPlayer Player2 { get; private set; }
    public Hand Player1Shape { get; private set; }
    public Hand Player2Shape { get; private set; }
    public int Player1Score { get; private set; }
    public int Player2Score { get; private set; }
    public int RoundWinner { get; private set; }
    public int Winner
    {
        get
        {
            if (Player1Score == Player2Score)
                return 0;
            else if (Player1Score > Player2Score)
                return 1;
            else
                return 2;
        }
    }
    public int Round { get; private set; }
    public bool WinnerIsDeterminated { get; private set; }

    public Battle(IPlayer player1, IPlayer player2)
    {
        Player1 = player1;
        Player1.StartNewBattle();
        Player2 = player2;
        Player2.StartNewBattle();
        Round = 1;
    }

    public void MakeRound()
    {
        Round++;
        Player1Shape = Player1.MakeMoveAsFirst();
        Player2Shape = Player2.MakeMoveAsSecond(Player1Shape);

        Player1.LastRoundResult(Player2Shape);
        Player2.LastRoundResult(Player1Shape);

        if (Player1Shape == Player2Shape)
            RoundWinner = 0;
        else if (Player1Shape > Player2Shape)
        {
            RoundWinner = 1;
            Player1Score++;
        }
        else
        {
            RoundWinner = 2;
            Player2Score++;
        }

        if (Player1Score * 2 > _summaryScore || Player2Score * 2 > _summaryScore || Round > 30)
            WinnerIsDeterminated = true;
    }
}
