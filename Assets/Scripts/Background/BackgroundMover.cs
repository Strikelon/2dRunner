using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxImagePosition = 1;

    private RawImage _image;
    private float _imagePositionX;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if (_imagePositionX > _maxImagePosition)
        {
            _imagePositionX = 0;
        }

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
