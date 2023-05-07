using System;
using UnityEngine;

namespace Sound
{
    public static class SoundManager
    {

        private static float _gameMusicVolume = 0.5f;
        private static float _characterEffectsVolume = 0.1f;
        public static event Action<float> OnGameMusicVolumeChanged;
        public static event Action<float> OnCharacterEffectsVolumeChanged;
        
        public enum CharacterSound
        {
            PlayerSwordSlash, 
            PlayerSwordMetalHit,
            PlayerDying,
            PlayerDrawSword,
            PlayerBlockHit,
            PlayerDamage,
            CreatureRoaring,
            CreatureDying,
            CreatureDamage
        }

        public enum GameSound
        {
            GameRegisteringSoundtrack,
            GameBackgroundMusic,
            ButtonClick,
            ButtonHover,
        }

        public static void PlayGameSound(GameSound gameSound)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetGameAudioClip(gameSound);
            audioSource.volume = _gameMusicVolume;
            audioSource.Play();
        }
        public static void PlayGameSound(GameSound gameSound, Vector3 position)
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = _gameMusicVolume;
            audioSource.clip = GetGameAudioClip(gameSound);
            audioSource.Play();
        }

        public static void PlayGameSound(GameSound gameSound, float delay, Vector3 position)
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = _gameMusicVolume;
            audioSource.clip = GetGameAudioClip(gameSound);
            audioSource.PlayDelayed(delay);
        }

        public static void PlayGameSound(GameSound gameSound, bool inLoop)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = _gameMusicVolume;
            audioSource.loop = inLoop;
            audioSource.PlayOneShot(GetGameAudioClip(gameSound));
        }
        
        public static float GameMusicVolume {
            get { return _gameMusicVolume; }
            set {
                _gameMusicVolume = value;
                if (OnGameMusicVolumeChanged != null) {
                    OnGameMusicVolumeChanged(_gameMusicVolume);
                }
            }
        }
        private static AudioClip GetGameAudioClip(GameSound gameSound)
        {
            foreach (GameSoundController.SoundAudioClip soundAudioClip in GameSoundController.i.soundAudioClips)
            {
                if (soundAudioClip.GameSound == gameSound)
                {
                    return soundAudioClip.AudioClip;
                }
            }
            Debug.LogError("Sound "+ gameSound+ " not found! ");
            return null;
        }
        
        
        public static void PlayCharacterSound(CharacterSound characterSound)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = _characterEffectsVolume;
            audioSource.clip = GetCharacterAudioClip(characterSound);
            audioSource.Play();
        }
        public static void PlayCharacterSound(CharacterSound characterSound, Vector3 position)
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = _characterEffectsVolume;
            audioSource.clip = GetCharacterAudioClip(characterSound);
            audioSource.Play();
        }

        public static void PlayCharacterSound(CharacterSound characterSound, float delay, Vector3 position)
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume =_characterEffectsVolume;
            audioSource.clip = GetCharacterAudioClip(characterSound);
            audioSource.PlayDelayed(delay);
        }

        public static void PlayCharacterSound(CharacterSound characterSound, bool inLoop)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = _characterEffectsVolume;
            audioSource.loop = inLoop;
            audioSource.PlayOneShot(GetCharacterAudioClip(characterSound));
        }
        

        private static AudioClip GetCharacterAudioClip(CharacterSound characterSound)
        {
            foreach (CharacterSoundController.SoundAudioClip soundAudioClip in CharacterSoundController.i.soundAudioClips)
            {
                if (soundAudioClip.CharacterSound == characterSound)
                {
                    return soundAudioClip.AudioClip;
                }
            }
            Debug.LogError("Sound "+ characterSound+ " not found! ");
            return null;
        }
        
        public static float CharacterEffectsVolume {
            get => _characterEffectsVolume;
            set {
                _characterEffectsVolume = value;
                if (OnCharacterEffectsVolumeChanged != null) {
                    OnCharacterEffectsVolumeChanged(_characterEffectsVolume);
                }
            }
        }
    }
}
