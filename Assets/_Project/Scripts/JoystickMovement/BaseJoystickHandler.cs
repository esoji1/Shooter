using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseJoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public abstract Image JoystickBackground { get; }
    public abstract Image Joystick { get; }
    public abstract Image JoystickArea { get; }

    private Vector2 _joystickBackgroundStartPosition;

    protected Vector2 _inputVector;

    private void Start() 
        => _joystickBackgroundStartPosition = JoystickBackground.rectTransform.anchoredPosition;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBackground.rectTransform,
            eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * 2 / JoystickBackground.rectTransform.sizeDelta.x);
            joystickPosition.y = (joystickPosition.y * 2 / JoystickBackground.rectTransform.sizeDelta.y);

            _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            _inputVector = (_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector;

            Joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (JoystickBackground.rectTransform.sizeDelta.x / 2),
                _inputVector.y * (JoystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 joystickBackgroundPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickArea.rectTransform,
            eventData.position, null, out joystickBackgroundPosition))
        {
            JoystickBackground.rectTransform.anchoredPosition = new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JoystickBackground.rectTransform.anchoredPosition = _joystickBackgroundStartPosition;

        _inputVector = Vector2.zero;
        Joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}