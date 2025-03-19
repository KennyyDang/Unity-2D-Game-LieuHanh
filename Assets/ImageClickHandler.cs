using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject helperContent; // Reference to the HelperContent GameObject
    
    void Start()
    {
        // Get the Image component (no need for Button component)
        Image image = GetComponent<Image>();
        
        // Add click detection using EventTrigger
        UnityEngine.EventSystems.EventTrigger trigger = GetComponent<UnityEngine.EventSystems.EventTrigger>();
        if (trigger == null)
            trigger = gameObject.AddComponent<UnityEngine.EventSystems.EventTrigger>();
            
        UnityEngine.EventSystems.EventTrigger.Entry entry = new UnityEngine.EventSystems.EventTrigger.Entry();
        entry.eventID = UnityEngine.EventSystems.EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { ToggleHelperContent(); });
        trigger.triggers.Add(entry);
        
        // Make sure the helper content is initially hidden
        if (helperContent != null)
            helperContent.SetActive(false);
    }
    
    public void ToggleHelperContent()
    {
        if (helperContent != null)
        {
            // Toggle the helper content visibility
            helperContent.SetActive(!helperContent.activeSelf);
        }
    }
}