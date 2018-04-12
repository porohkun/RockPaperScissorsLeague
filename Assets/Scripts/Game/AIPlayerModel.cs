using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIPlayerModel : ScriptableObject
{
    public const string AssetsFolder = "Assets/Resources/AIPlayers";

    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }

    [SerializeField]
    private string _description;
    public string Description { get { return _description; } }

    [SerializeField]
    private Sprite _icon;
    public Sprite Icon { get { return _icon; } }

    [SerializeField]
    private AIStrategy _strategy;
    public AIStrategy Strategy { get { return _strategy; } }
}
