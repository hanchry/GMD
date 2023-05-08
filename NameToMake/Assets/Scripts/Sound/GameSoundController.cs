using UnityEngine;
using UnityEngine.Serialization;

namespace Sound
{
    public class GameSoundController : MonoBehaviour
    {
        private static GameSoundController _i;

        public static GameSoundController I
        {
            get
            {
                if (_i == null)
                {
                    _i = Instantiate(Resources.Load<GameSoundController>("GameSoundController"));
                    
                } 
                return _i;
            }
        }

        [FormerlySerializedAs("SoundAudioClips")] 
        public SoundAudioClip[] soundAudioClips;
    
        [System.Serializable]
        public class SoundAudioClip
        {
            [FormerlySerializedAs("GameSound")] 
            public SoundManager.GameSound gameSound;
            [FormerlySerializedAs("AudioClip")] 
            public AudioClip audioClip;
            
        }
    }
}