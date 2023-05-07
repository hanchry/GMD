using System;
using Objects;
using TMPro;
using UnityEngine;

namespace CanvasView
{
    public class ItemElement:MonoBehaviour
    {
        public void OnHover()
        {
            GameObject placeHolder = GameObject.Find("Canvas");
            GameObject stats = Instantiate(Resources.Load("Prefabs/UI/ItemStats")) as GameObject;
            stats.transform.SetParent(placeHolder.transform, false);
            Vector2 pos = Input.mousePosition;

            stats.GetComponent<RectTransform>().localPosition = new Vector3(pos.x - 700, pos.y-300, 0);
            
            WeaponLogic weapon = transform.GetComponent<WeaponLogic>();
            //find gameobject with name "StatsValue" inside stats
            GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = weapon.WeaponName.ToString();
            GameObject.Find("TypeValue").GetComponent<TextMeshProUGUI>().text = weapon.WeaponType.ToString();
            GameObject.Find("DamageValue").GetComponent<TextMeshProUGUI>().text = weapon.MinDamage.ToString() + " - " + weapon.MaxDamage.ToString();
            GameObject.Find("CriticValue").GetComponent<TextMeshProUGUI>().text = weapon.CriticalDamage.ToString();
        }
        public void OnHoverExit()
        {
            Destroy(GameObject.Find("ItemStats(Clone)"));
        }
    }
}