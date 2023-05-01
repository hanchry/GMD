using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private bool canDealDamage;

    private List<GameObject> hasDealtDamage;

    [SerializeField] private float weaponLength;
    [SerializeField] private float weaponDamage;
    
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                if (!hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    print("damage");
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true; 
        hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        canDealDamage = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        var transform1 = transform;
        var position = transform1.position;
        Gizmos.DrawLine(position, position - transform1.up * weaponLength);
    }
}
