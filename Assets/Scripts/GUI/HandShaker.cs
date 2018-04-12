using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HandShaker : MonoBehaviour
{
    [Serializable]
    public class HandShapeData
    {
        [SerializeField]
        private HandType _shape;
        public HandType Shape { get { return _shape; } }

        [SerializeField]
        private Sprite _image;
        public Sprite Image { get { return _image; } }
    }

    public event Action ShakeEnded;
    public event Action WinEnded;

    [SerializeField]
    private Image _handShape;
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private HandShapeData[] _handShapeSprites;

    public void OnShakeEnd()
    {
        if (ShakeEnded != null)
            ShakeEnded();
    }

    public void OnWinEnd()
    {
        if (WinEnded != null)
            WinEnded();
    }

    public void SetHandShape(Hand hand)
    {
        foreach (var shape in _handShapeSprites)
            if (shape.Shape == hand)
                _handShape.sprite = shape.Image;
    }

    public void StartShake()
    {
        _animator.SetTrigger("Shake");
    }

    public void StartWin()
    {
        _animator.SetTrigger("Win");
    }
}
