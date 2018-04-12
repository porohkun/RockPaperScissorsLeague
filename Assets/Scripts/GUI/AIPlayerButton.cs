using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AIPlayerButton : MonoBehaviour
{
    [SerializeField]
    private Image _icon;

    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private Text _descriptionText;

    public AIPlayerModel Player { get; private set; }

    public event Action<AIPlayerModel> Clicked;

    public void ShowPlayer(AIPlayerModel player)
    {
        Player = player;
        _icon.sprite = player.Icon;
        _nameText.text = player.Name;
        _descriptionText.text = player.Description;
    }

    public void OnClick()
    {
        if (Clicked != null)
            Clicked(Player);
    }
}
