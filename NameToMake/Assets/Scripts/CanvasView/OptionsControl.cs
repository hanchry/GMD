using System;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class OptionsControl:MonoBehaviour
    {
        public void OnClickBack()
        {
            SceneManager.LoadScene("Menu");
        }
        public void OnClickApply()
        {
            GameObject.Find("Sound").GetComponent<AudioSource>().volume = 0f;
            Debug.Log("Apply");
        }
        public void OnMusicSliderChanged()
        {
            if (_isStaret)
            {
                float value = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
                GameObject.Find("Sound").GetComponent<AudioSource>().volume = value;
                SoundManager.GameMusicVolume = value;
            }
        }
        public void OnSoundSliderChanged()
        {
            if (_isStaret)
            {
                float value1 = GameObject.Find("SoundSlider").GetComponent<Slider>().value;
                SoundManager.CharacterEffectsVolume = value1;
            }
        }

        private bool _isStaret = false;
        private void Start()
        {
            GameObject.Find("MusicSlider").GetComponent<Slider>().value = SoundManager.GameMusicVolume;
            GameObject.Find("SoundSlider").GetComponent<Slider>().value = SoundManager.CharacterEffectsVolume;
            _isStaret = true;
            // SoundManager.PlayGameSound(SoundManager.GameSound.GameRegisteringSoundtrack,true);
        }
    }
}