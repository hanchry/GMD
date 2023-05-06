using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Objects
{
    public class Inventory : MonoBehaviour,IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedObject = eventData.pointerDrag;
            DragableObject dragableObject = droppedObject.GetComponent<DragableObject>(); 
            
            if (transform.childCount > 0)
            {
                Transform child = transform.GetChild(0);
                child.SetParent(dragableObject.parentToReturnTo);
                child.localPosition = new Vector3(child.GetComponent<RawImage>().rectTransform.rect.width/2, 0, 0);
            }
            SaveItem(droppedObject);
            dragableObject.itemShift = true;
            dragableObject.parentToReturnTo = transform;
        }
        
        private void SaveItem(GameObject droppedObject)
        {
            string itemName = droppedObject.name.Replace("(Clone)", "");
            string[] items = Items.Instance.GetInventoryItems();
            if (!items.Contains(itemName))
            {
                Items.Instance.AddInventoryItem(itemName);
            }
        }
    }
}