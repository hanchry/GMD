using System;
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
            
            if (IsItemCorrect(droppedObject.name))
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

        private bool IsItemCorrect(String name)
        {
            name = name.Replace("(Clone)", "");
            
            foreach (var item in items)
            {
                if (item.Key.Equals(transform.name))
                {
                    GameObject uiItem = Instantiate(Resources.Load("Prefabs/UI/Items/" + name)) as GameObject;
                    if (uiItem.GetComponent(item.Value) != null)
                    {
                        Items.Instance.RemoveInventoryItem(name);
                        Items.Instance.SetWeapon1(name);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        
        
    }
}