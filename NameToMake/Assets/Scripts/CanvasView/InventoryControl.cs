using System;
using Objects;
using UnityEngine;

namespace CanvasView
{
    public class InventoryControl:MonoBehaviour
    {
        void Start()
        {
            SetupInventory();
            SetupEquiptWeapon1();
        }

        private void SetupInventory()
        {
            foreach (var item in Items.Instance.GetInventoryItems())
            {
                if (item != "")
                {
                    if (GameObject.Find(item+"(Clone)") != null)
                        Destroy(GameObject.Find(item+"(Clone)"));
                    else
                    {
                        //find objects that contains in its name "InventorySlot"
                        GameObject placeHolder = FindPlaceHolderInventory();
                        GameObject uiItem = Instantiate(Resources.Load("Prefabs/UI/Items/" + item)) as GameObject;
                        uiItem.transform.SetParent(placeHolder.transform, false);
                        uiItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                    }
                }
            }
        }

        private void SetupEquiptWeapon1()
        {
            string item = Items.Instance.Weapon1;
            GameObject placeHolder = GameObject.Find("Weapon1");
            GameObject uiItem = Instantiate(Resources.Load("Prefabs/UI/Items/" + item)) as GameObject;
            uiItem.transform.SetParent(placeHolder.transform, false);
            uiItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        
        private GameObject FindPlaceHolderInventory()
        {
            //get all objects that contains in its name "InventorySlot"
            GameObject[] placeHolders = GameObject.FindGameObjectsWithTag("InventorySlot");
            foreach (var slot in placeHolders)
            {
                if (slot.transform.childCount == 0)
                {
                    return slot;
                }
            }

            return null;
        }
        
        
    }
    
}