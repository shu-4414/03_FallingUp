using UnityEngine;
using UnityEngine.EventSystems;

public class TapCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (EventSystem.current == null)
        {
            Debug.LogWarning("EventSystem‚ªƒV[ƒ“‚É‚ ‚è‚Ü‚¹‚ñB");
        }
        var CurrentTrigger = gameObject.AddComponent<EventTrigger>();

        var EntryClick = new EventTrigger.Entry();
        EntryClick.eventID = EventTriggerType.PointerClick; 
        EntryClick.callback.AddListener((x) => OnTap());

        CurrentTrigger.triggers.Add(EntryClick);
    }

    

    protected virtual void OnTap()
    {

    }

    private void OnMouseDown()
    {
        OnTap();
    }
}
