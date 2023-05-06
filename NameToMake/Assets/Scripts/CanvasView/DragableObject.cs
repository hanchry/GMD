
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Objects
{
    public class DragableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RawImage image;
        [HideInInspector] public Transform parentToReturnTo;
        [HideInInspector] public bool itemShift;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            parentToReturnTo = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentToReturnTo);
            float x = 0;
            if (itemShift)
            {
                x = image.rectTransform.rect.width/2;
            }
            transform.localPosition = new Vector3(x, 0, 0);
            image.raycastTarget = true;
        }
    }
}