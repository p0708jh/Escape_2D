using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    Vector2 touch = Vector2.zero;
    public RectTransform handle;
    public move_player mp;
    float widthHalf;

    public joystick_value value;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / widthHalf;
        if (touch.magnitude > 1.0f)
            touch = touch.normalized;
        value.joyTouch = touch;
        handle.anchoredPosition = touch *widthHalf;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        value.joyTouch = Vector2.zero;
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
    }
}
