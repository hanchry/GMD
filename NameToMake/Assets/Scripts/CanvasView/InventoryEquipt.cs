using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Objects
{
    public class InventoryEquipt: MonoBehaviour,IDropHandler
    {
        
        private Dictionary<string, string> items = new Dictionary<string, string>()
        {
            {ItemType.Weapon1.ToString(), "WeaponLogic"},
            {ItemType.Weapon2.ToString(), ""},
            {ItemType.HeadArmor.ToString(), ""},
            {ItemType.ChestArmor.ToString(), ""},
            {ItemType.LegArmor.ToString(), ""},
        };
        
        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedObject = eventData.pointerDrag;
            if (IsItemTypeEqualToSlotType(droppedObject))
            {
                DragableObject dragableObject = droppedObject.GetComponent<DragableObject>(); 
                if (transform.childCount > 1)
                {
                    Transform child = transform.GetChild(1);
                    child.SetParent(dragableObject.parentToReturnTo);
                    child.localPosition = new Vector3(child.GetComponent<RawImage>().rectTransform.rect.width/2, 0, 0);
                }
            
                dragableObject.itemShift = false;
                dragableObject.parentToReturnTo = transform;
            }
        }

        private bool IsItemTypeEqualToSlotType(GameObject droppedObject)
        {
            foreach (var item in items)
            {
                if (transform.name.Contains(item.Key))
                {
                    if (droppedObject.GetComponent(item.Value) != null)
                    {
                        string itemName = droppedObject.name.Replace("(Clone)", "");
                        Items.Instance.GetType().GetProperty(item.Key)?.SetValue(Items.Instance, itemName);
                        Items.Instance.RemoveInventoryItem(itemName);
                        
                        return true;
                    }
                }
            }
            return false;
        }
    }
}