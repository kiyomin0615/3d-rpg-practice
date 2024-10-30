using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Action<PointerEventData> OnbeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnbeginDragHandler != null)
            OnbeginDragHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }
}
