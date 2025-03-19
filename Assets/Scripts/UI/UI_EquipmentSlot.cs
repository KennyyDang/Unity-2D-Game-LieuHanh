using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UI_EquipmentSlot : UI_ItemSlot
{
    public EquipmentType slotType;

    private void OnValidate()
    {
        gameObject.name = "Ô trang bị - " + GetInspectorName(slotType);
    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        if (item == null || item.data == null)
            return;
        
        Inventory.instance.UnequipItem(item.data as ItemData_Equipment);
        Inventory.instance.AddItem(item.data as ItemData_Equipment);
        
        ui.itemToolTip.HideToolTip();
        
        CleanUpSlot();
    }

    private string GetInspectorName(Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        InspectorNameAttribute attr = field.GetCustomAttribute<InspectorNameAttribute>();
        return attr != null ? attr.displayName : value.ToString();
    }
}
