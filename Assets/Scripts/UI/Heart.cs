using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _filledHeart;
    [SerializeField] private Sprite _emptyHeart;

    public void ToFill()
    {
        _image.sprite = _filledHeart;
    }

    public void ToEmpty()
    {
        _image.sprite = _emptyHeart;
    }
}
