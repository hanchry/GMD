using System;
using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class CombatValues : MonoBehaviour
{
    [SerializeField]
    private AtributesSkills _atributesSkills;
    

    public Damage DamageGiven()
    {
        int critical = Critic() ? 2 : 1;
        Damage damage = new Damage();
        damage.Value = DamageFromWeapon(1, 10) * critical;
        damage.Type = DamageType.Heavy;
        
        
        return damage;
    }
    
    public Damage DamageReceived(Damage damage)
    {
        bool block = Block();
        bool dodge = Dodge();
        if (block || dodge)
        {
            damage.Value = 0;
            damage.Type = block ? DamageType.Block : DamageType.Dodge;
        }
        return damage;
    }

    private void Start()
    {
        // Debug.Log(Items.Instance.Weapon1);
        
    }


    private bool Block()
    {
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance <= 20)
        {
            return true;
        }
        return false;
    }
    private bool Dodge()
    {
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance <= 20)
        {
            return true;
        }
        return false;
    }
    private bool Critic()
    {
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance <= 20)
        {
            return true;
        }
        return false;
    }
    private int DamageFromWeapon(int minDamage, int maxDamage)
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        return damage;
    }
    
}
