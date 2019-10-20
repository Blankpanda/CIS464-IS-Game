using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine;

public class SelectObject : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler
{
    public static HashSet<SelectObject> allSelectedObjects = new HashSet<SelectObject>();
    public static HashSet<SelectObject> currentlySelected = new HashSet<SelectObject>();

    SpriteRenderer sr;

    [SerializeField]
    Sprite unselectedSprite;
    [SerializeField]
    Sprite selectedSprite;

    void Awake()
    {
        allSelectedObjects.Add(this);
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            DeselectAll(eventData);
        }
        currentlySelected.Add(this);
        sr.sprite = selectedSprite;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        throw new NotImplementedException();
        sr.sprite = unselectedSprite;
    }

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach(SelectObject selectable in currentlySelected)
        {
            selectable.OnDeselect(eventData);
        }
        currentlySelected.Clear();
    }
}
