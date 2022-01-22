using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private Text _content;
    [SerializeField] private Button _button;

    public void SetInformation(string content)
    {
        _content.text = content;
    }

    public void AddOnClickListener(Action onCLickCallBack)
    {
        _button.onClick.AddListener(onCLickCallBack.Invoke);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}