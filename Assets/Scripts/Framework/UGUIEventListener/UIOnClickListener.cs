using UnityEngine;
using UnityEngine.EventSystems;

public class UIOnClickListener : EventTrigger
{

    public delegate void OnClickDelegate(GameObject go);
    public OnClickDelegate onClick;

    public static UIOnClickListener Get(GameObject go)
    {
        UIOnClickListener listener = go.GetComponent<UIOnClickListener>();
        if (listener == null)
            listener = go.AddComponent<UIOnClickListener>();
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(gameObject);
    }

}
