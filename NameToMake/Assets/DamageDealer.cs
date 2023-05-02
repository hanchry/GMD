using System;
using System.Collections;
using System.Collections.Generic;
using PlayerControls.CreatureControl;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class DamageDealer : MonoBehaviour
{
    private bool canDealDamage;

    private List<GameObject> hasDealtDamage;

    [SerializeField] private float weaponLength;
    [SerializeField] private int weaponDamage;
    
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
        // will be taken from Andrej's ui/ or add a listener to those values
        weaponDamage = 40;
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
                if (hit.transform.TryGetComponent(out Creature creature) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    Debug.Log("damage");
                    creature.TakeDamage(weaponDamage);
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
