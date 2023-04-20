using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttributes playerAttributes = new PlayerAttributes(100);
        Debug.Log("Health:"+playerAttributes.Health);
        playerAttributes.Damage(10);
        playerAttributes.Heal(5);
        Debug.Log("Health:"+playerAttributes.Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
