using System;
using Objects;
using UnityEngine;

namespace CanvasView
{
    public class InventoryControl:MonoBehaviour
    {
        void Start()
        {
            // Invoke("DuplicateFix", 0.00001f);
            Invoke("SetupInventory", 0.00001f);
            Invoke("SetupEquiptWeapon1", 0.00001f);
        }

        private void DuplicateFix()
        {
            Items.Instance.RemoveInventoryItem("SwordLight");
        }
        private void SetupInventory()
        {
            Debug.Log("SetupInventory");
            foreach (var item in Items.Instance.GetInventoryItems())
            {
                if (!String.IsNullOrEmpty(item))
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
            string item = Items.Instance.GetWeapon1();
            item = Items.Instance.GetWeapon1();
            Debug.Log(item);
            if (!String.IsNullOrEmpty(item))
            {
                GameObject placeHolder = GameObject.Find("Weapon1");
                GameObject uiItem = Instantiate(Resources.Load("Prefabs/UI/Items/" + item)) as GameObject;
                uiItem.transform.SetParent(placeHolder.transform, false);
                uiItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            }
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