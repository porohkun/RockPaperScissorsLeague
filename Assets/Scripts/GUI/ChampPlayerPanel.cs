using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ChampPlayerPanel : MonoBehaviour
{
    [SerializeField]
    private Text _place;

    [SerializeField]
    private Image _icon;

    [SerializeField]
    private Sprite _defaultSprite;

    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private Text _descriptionText;

    public IPlayer Player { get; private set; }

    public void ShowPlayer(IPlayer player, int place)
    {
        _place.text = place.ToString();
        Player = player;
        _icon.sprite = player.Icon != null ? player.Icon : _defaultSprite;
        _nameText.text = player.Name;
        _descriptionText.text = player.Description;
    }

}
