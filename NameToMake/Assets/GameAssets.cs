using System.Collections;
using System.Collections.Generic;
using Sound;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            } 
            return _i;
        }
    }

    public SoundAudioClip[] SoundAudioClips;
    
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip AudioClip;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
