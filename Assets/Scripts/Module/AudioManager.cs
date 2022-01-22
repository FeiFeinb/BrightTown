using System;
using System.Collections;
using System.Collections.Generic;
using Module;
using UnityEngine;

public class AudioManager : BaseSingletonWithMono<AudioManager>
{
    public enum BGMType
    {
        Start, Main, End
    }
    
    [SerializeField] private AudioSource _buttonAudio;
    [SerializeField] private AudioSource _buildingAudio;
    [SerializeField] private AudioSource _QuestionnaireAudio;
    [SerializeField] private AudioSource _weatherAudio;
    [SerializeField] private AudioSource _musicAudio;

    [Space]
    
    [SerializeField] private AudioClip _buildingAudioClip;
    [SerializeField] private AudioClip _buildFinishAudioClip;

    [SerializeField] private AudioClip _sunnyAudioClip;
    [SerializeField] private AudioClip _rainyAudioClip;

    [SerializeField] private AudioClip _startSceneAudioClip;
    [SerializeField] private AudioClip _mainSceneAudioClip;
    [SerializeField] private AudioClip _endSceneAudioClip;
    
    public void PlayButtonClickSound()
    {
        _buttonAudio.Play();
    }

    public void PlayQuestionnaireSound()
    {
        _QuestionnaireAudio.Play();
    }

    public void PlayBuildSound(bool isFinish)
    {
        _buildingAudio.clip = isFinish ? _buildFinishAudioClip : _buildingAudioClip;
        _buildingAudio.Play();
    }

    public void SwitchWeatherSound(bool isSunny)
    {
        _weatherAudio.Stop();
        _weatherAudio.clip = isSunny ? _sunnyAudioClip : _rainyAudioClip;
        _weatherAudio.Play();
    }

    public void SwitchBGMSound(BGMType bgmType)
    {
        _musicAudio.Stop();
        switch (bgmType)
        {
            case BGMType.Start:
                _musicAudio.clip = _startSceneAudioClip;
                break;
            case BGMType.Main:
                _musicAudio.clip = _mainSceneAudioClip;
                break;
            case BGMType.End:
                _musicAudio.clip = _endSceneAudioClip;
                break;
        }
        _musicAudio.Play();
    }
    
    public void SetSoundEffectVolume(float value)
    {
        _buttonAudio.volume = value;
        _weatherAudio.volume = value;
        _buildingAudio.volume = value;
        _QuestionnaireAudio.volume = value;
    }

    public void SetMusicVolume(float value)
    {
        _musicAudio.volume = value;
    }
}
