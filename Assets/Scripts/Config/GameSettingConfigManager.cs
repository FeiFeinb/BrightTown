using System.Collections;
using System.Collections.Generic;
using Module;
using UnityEngine;

public class GameSettingConfigManager : BaseSingletonWithMono<GameSettingConfigManager>
{
    public float SoundEffective
    {
        get
        {
            return _soundEffective;
        }
        set
        {
            _soundEffective = value;
            AudioManager.Instance.SetSoundEffectVolume(value);
        }
    }

    public float Music
    {
        get
        {
            return _music;
        }
        set
        {
            _music = value;
            AudioManager.Instance.SetMusicVolume(value);
        }
    }

    public float DialogueTextSpeed
    {
        get
        {
            return _dialogueTextSpeed;
        }
        set
        {
            _dialogueTextSpeed = value;
        }
    }

    public float DialogueMaxSpeedPerWord => _dialogueMaxSpeedPerWord;
    
    public float DialogueMinSpeedPerWord => _dialogueMinSpeedPerWord;
    
    [SerializeField] private float _soundEffective = 1;

    [SerializeField] private float _music = 1;
    
    [SerializeField] private float _dialogueTextSpeed = 0.05f;

    [SerializeField] private float _dialogueMaxSpeedPerWord = 0.04f;
    
    [SerializeField] private float _dialogueMinSpeedPerWord = 0.2f;
}
