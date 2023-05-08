using UnityEngine;
using UnityEngine.Serialization;

namespace Sound
{
    public class CharacterSoundController : MonoBehaviour
    {
        private static CharacterSoundController _i;

        public static CharacterSoundController I
        {
            get
            {
                if (_i == null)
                {
                    _i = Instantiate(Resources.Load<CharacterSoundController>("CharacterSoundController"));
                } 
                return _i;
            }
        }

        [FormerlySerializedAs("SoundAudioClips")] 
        public SoundAudioClip[] soundAudioClips;
    
        [System.Serializable]
        public class SoundAudioClip
        {
            [FormerlySerializedAs("CharacterSound")] 
            public SoundManager.CharacterSound characterSound;
          
            [FormerlySerializedAs("AudioClip")] 
            public AudioClip audioClip;
        
        }
    }
}