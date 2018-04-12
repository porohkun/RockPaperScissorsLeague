using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIStrategy : ScriptableObject
{
    public const string AssetsFolder = "Assets/Resources/AIStrategies";

    public event Action<string> CustomMessage;

    protected Hand _lastOppHand { get;private set; }
    protected Hand _lastOwnHand { get; private set; }
    protected int _lastRoundResult { get; private set; }
    protected int _ownScore { get; private set; }
    protected int _oppScore { get; private set; }

    public virtual void Initialize()
    {

    }

    protected void SendCustomMessage(string message)
    {
        if (CustomMessage != null)
            CustomMessage(message);
    }

    public Hand MakeMove(Hand opponentMove)
    {
        _lastOwnHand = MakeMoveInternal(opponentMove);
        return _lastOwnHand;
    }

    protected virtual Hand MakeMoveInternal(Hand opponentMove)
    {
        throw new NotImplementedException();
    }

    public Hand MakeMove()
    {
        _lastOwnHand = MakeMoveInternal();
        return _lastOwnHand;
    }

    protected virtual Hand MakeMoveInternal()
    {
        throw new NotImplementedException();
    }

    public virtual void LastRound(Hand oppHand)
    {
        _lastOppHand = oppHand;
        _lastRoundResult = _lastOwnHand.CompareTo(_lastOppHand);
        if (_lastRoundResult > 0)
            _ownScore++;
        else if (_lastRoundResult < 0)
            _oppScore++;
    }
}

