using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum HandType : int
{
    Rock = 0,
    Paper = 1,
    Scissors = 2,
}

public class Hand : IComparable<HandType>, IComparable<Hand>, IEquatable<HandType>, IEquatable<Hand>
{
    private static Hand _rock = new Hand(HandType.Rock);
    private static Hand _paper = new Hand(HandType.Paper);
    private static Hand _scissors = new Hand(HandType.Scissors);

    public static Hand Rock { get { return _rock; } }
    public static Hand Paper { get { return _paper; } }
    public static Hand Scissors { get { return _scissors; } }

    private static int[] _results;

    static Hand()
    {
        _results = new int[9];
        _results[Offset(HandType.Rock, HandType.Rock)] = 0;
        _results[Offset(HandType.Rock, HandType.Paper)] = -1;
        _results[Offset(HandType.Rock, HandType.Scissors)] = 1;
        _results[Offset(HandType.Paper, HandType.Rock)] = 1;
        _results[Offset(HandType.Paper, HandType.Paper)] = 0;
        _results[Offset(HandType.Paper, HandType.Scissors)] = -1;
        _results[Offset(HandType.Scissors, HandType.Rock)] = -1;
        _results[Offset(HandType.Scissors, HandType.Paper)] = 1;
        _results[Offset(HandType.Scissors, HandType.Scissors)] = 0;
    }

    public Hand(HandType type)
    {
        Type = type;
    }

    private static int Offset(HandType self, HandType other)
    {
        return 3 * (int)self + (int)other;
    }

    public HandType Type { get; private set; }

    public bool IsRock { get { return Type == HandType.Rock; } }
    public bool IsPaper { get { return Type == HandType.Paper; } }
    public bool IsScissors { get { return Type == HandType.Scissors; } }

    public static bool operator >(Hand a1, Hand a2)
    {
        return a1.CompareTo(a2) > 0;
    }

    public static bool operator <(Hand a1, Hand a2)
    {
        return a1.CompareTo(a2) < 0;
    }

    public static bool operator >(Hand a1, HandType a2)
    {
        return a1.CompareTo(a2) > 0;
    }

    public static bool operator <(Hand a1, HandType a2)
    {
        return a1.CompareTo(a2) < 0;
    }

    //public static bool operator ==(Hand a1, Hand a2)
    //{
    //    return a1.Equals(a2);
    //}

    //public static bool operator !=(Hand a1, Hand a2)
    //{
    //    return !a1.Equals(a2);
    //}

    public static bool operator ==(Hand a1, HandType a2)
    {
        return a1.Equals(a2);
    }

    public static bool operator !=(Hand a1, HandType a2)
    {
        return !a1.Equals(a2);
    }

    public static bool operator ==(HandType a2, Hand a1)
    {
        return a1.Equals(a2);
    }

    public static bool operator !=(HandType a2, Hand a1)
    {
        return !a1.Equals(a2);
    }

    public static Hand operator ++(Hand a1)
    {
        return new Hand((HandType)(((int)a1.Type + 1) % 3));
    }

    public static Hand operator --(Hand a1)
    {
        return new Hand((HandType)(((int)a1.Type + 2) % 3));
    }

    public int CompareTo(HandType other)
    {
        return _results[Offset(Type, other)];
    }

    public int CompareTo(Hand other)
    {
        return _results[Offset(Type, other.Type)];
    }

    public bool Equals(HandType other)
    {
        return Type == other;
    }

    public bool Equals(Hand other)
    {
        return Type == other.Type;
    }
}
