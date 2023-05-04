using UnityEngine;
using UnityEngine.EventSystems;

namespace Objects
{
    public class Inventory : MonoBehaviour,IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedObject = eventData.pointerDrag;
            DragableObject dragableObject = droppedObject.GetComponent<DragableObject>();
            dragableObject.parentToReturnTo = transform;
        }
    }
}