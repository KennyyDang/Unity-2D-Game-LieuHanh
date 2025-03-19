using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class EquipmentTypeExtensions
    {
        public static string GetInspectorName(this EquipmentType value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            InspectorNameAttribute attr = field.GetCustomAttribute<InspectorNameAttribute>();
            return attr != null ? attr.displayName : value.ToString();
        }
    }
}
