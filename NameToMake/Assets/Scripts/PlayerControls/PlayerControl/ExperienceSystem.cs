using System;
using UnityEngine;

namespace PlayerControls.PlayerControl
{
    
    public class LevelChangedEventArgs : EventArgs
    {
        public int NewLevel { get; set; }

        public LevelChangedEventArgs(int newLevel)
        {
            NewLevel = newLevel;
        }
    }
    public class ExperienceSystem 
    {
        public event EventHandler OnExperienceChanged;
        public event EventHandler<LevelChangedEventArgs> LevelChanged;
        
        private int _experience;
        private int _experienceLevel;
        private int _level;

        private static ExperienceSystem _instance;
        
        private ExperienceSystem(int experience,int experienceLevel,int level)
        {
            this._experienceLevel = experienceLevel;
            _experience = experience;
            _level = level;
        }

        private ExperienceSystem(int experience)
        {
            _experience = experience;
        }

        public static ExperienceSystem Instance(int experience)
        {
            if (_instance == null)
            {
                    _instance = new ExperienceSystem(experience);
            }
            return _instance;
        }
        public int GetCurrentExperience()
        {
            return _experience;
        }

        public float GetLevelExperiencePercent()
        {
            return (float) _experience / _experienceLevel;
        }

        public void GetExperience(int experienceAmount)
        {
            _experience += experienceAmount;
          //  NotifyChangedLevel();
            if(OnExperienceChanged!=null) OnExperienceChanged(this,EventArgs.Empty);
        }

        public void NotifyChangedLevel()
        {
            if (_experience > _experienceLevel)
            {
                _experience = _experienceLevel;
                if(LevelChanged!=null) LevelChanged?.Invoke(this, new LevelChangedEventArgs(_level++));
            }
        }
       
        
    }
}