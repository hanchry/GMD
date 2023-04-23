using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using PlayerControls;
using UnityEngine;
using Objects;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private HealthSystem _healthSystem;
    
    private AtributesSkills _attributeSkills;

    private Button DamageButton;
    private Button HealButton;

    public PlayerHealthCanvas _playerHealthCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //_attributeSkills get the max hp from here
        _healthSystem = new HealthSystem(100);

        _playerHealthCanvas.Setup(_healthSystem);
        
        DamageButton = GameObject.Find("Damage").GetComponent<Button>();
        HealButton = GameObject.Find("Heal").GetComponent<Button>();
        
        DamageButton.onClick.AddListener(() =>
        {
            _healthSystem.Damage(10);
            Debug.Log("damage clicked: "+_healthSystem.GetHealth());
        });
        HealButton.onClick.AddListener(() =>
        {
            _healthSystem.Heal(5);
            Debug.Log("heal clicked: " +_healthSystem.GetHealth());
        });
    }

    // Update is called once per frame
    void Update()
    {
        // DamageButton.onClick.AddListener(() =>
        // {
        //    _healthSystem.Damage(10);
        // });
        // DamageButton.onClick.AddListener(() =>
        // {
        //     _healthSystem.Heal(5);
        // });
    }

   
}
