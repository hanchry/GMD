using UnityEngine;

namespace Sound
{
    public static class SoundManager 
    {

        public enum Sound
        {
            GameRegisteringSoundtrack,
            GameBackgroundMusic,
            ButtonClick,
            PlayerMove,
            PlayerSwordSlash,
            PlayerSwordHit,
            PlayerDying,
            PlayerDrawSword,
            PlayerBlockHit,
            PlayerDamage,
            CreatureGrunting,
            CreatureRoaring,
            CreatureDying,
            CreatureAttack,
            CreatureDamage
            
        }
        public enum GameSounds
        {
            GameRegisteringSoundtrack,
            GameBackgroundMusic,
            ButtonClick
        }
        public enum PlayerSounds
        {
            PlayerMove,
            PlayerSwordSlash,
            PLayerSwordHit,
            PlayerDying,
            PlayerDrawSword,
            PlayerBlockHit,
            PlayerDamage
        }
        
        public enum CreatureSounds
        {
            CreatureGrunting,
            CreatureRoaring,
            CreatureDying,
            CreatureAttack,
            CreatureDamage
        }

        public static void PlaySound(Sound sound)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
        // public static void PlaySound()
        // {
        //     GameObject soundGameObject = new GameObject("Sound");
        //     AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        //    // audioSource.PlayDelayed(0.2f);
        //    // audioSource.PlayOneShot(GetAudioClip(sound));
        // }

        private static AudioClip GetAudioClip(Sound sound)
        {
            foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.SoundAudioClips)
            {
                if (soundAudioClip.sound == sound)
                {
                    return soundAudioClip.AudioClip;
                }
            }
            Debug.LogError("Sound "+ sound+ " not found! ");
            return null;
        }
    }
}
