using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class Tournament
{
    private List<IPlayer> _players = new List<IPlayer>();
    public IEnumerable<IPlayer> Players { get { return _players; } }

    private List<Battle> _lastBattles = new List<Battle>();
    public IEnumerable<Battle> LastBattles { get { return _lastBattles; } }

    public void AddPlayer(IPlayer player)
    {
        _players.Add(player);
    }

    IEnumerator _lap;

    public Battle RunLap()
    {
        _lap = RunOneLap(true);
        while (_lap.MoveNext())
            if (_lap.Current is Battle)
                return _lap.Current as Battle;
        return null;
    }

    public void ContinueLap()
    {
        while (_lap.MoveNext())
        { }
    }

    private IEnumerator RunOneLap(bool withResults)
    {
        for (int i = 0; i < _players.Count - 1; i++)
        {
            Battle battle;
            if (_players[i] is Player)
            {
                continue;
            }
            else if (_players[i + 1] is Player)
            {
                battle = new Battle(_players[i + 1], _players[i]);
                yield return battle;
                if (battle.Winner == 1)
                {
                    _players.RemoveAt(i + 1);
                    _players.Insert(i, battle.Player1);
                }
                if (withResults)
                    AddBattle(battle);
            }
            else
            {
                battle = new Battle(_players[i + 1], _players[i]);
                while (!battle.WinnerIsDeterminated)
                    battle.MakeRound();
                if (battle.Winner == 1)
                {
                    _players.RemoveAt(i + 1);
                    _players.Insert(i, battle.Player1);
                }
                if (withResults)
                    AddBattle(battle);
            }
        }
    }

    private void AddBattle(Battle battle)
    {
        _lastBattles.Add(battle);
        while (_lastBattles.Count > 10)
            _lastBattles.RemoveAt(0);
    }

    public void RunLaps(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var lap = RunOneLap(true);
            while (lap.MoveNext())
            { }
        }
    }
}

