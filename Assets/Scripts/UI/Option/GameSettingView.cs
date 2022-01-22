using UICore;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingView : BaseUIPanel
{
    [SerializeField] private Slider _soundEffectiveSlider;

    [SerializeField] private Slider _musicSlider;

    [SerializeField] private Slider _dialogueTextSpeedSlider;

    public override void Init()
    {
        base.Init();
        var ins = GameSettingConfigManager.Instance;
        
        _soundEffectiveSlider.value = ins.SoundEffective;
        _musicSlider.value = ins.Music;
        _dialogueTextSpeedSlider.value = (ins.DialogueTextSpeed - ins.DialogueMaxSpeedPerWord) / 
            (ins.DialogueMinSpeedPerWord - ins.DialogueMaxSpeedPerWord);

        _soundEffectiveSlider.onValueChanged.AddListener(delegate(float value)
        {
            ins.SoundEffective = Mathf.Clamp01(value);
        });

        _musicSlider.onValueChanged.AddListener(delegate(float value)
        {
            ins.Music = Mathf.Clamp01(value);
        });

        _dialogueTextSpeedSlider.onValueChanged.AddListener(delegate(float value)
        {
            ins.DialogueTextSpeed = Mathf.Lerp(
                ins.DialogueMaxSpeedPerWord, ins.DialogueMinSpeedPerWord,
                value);
        });
    }
}