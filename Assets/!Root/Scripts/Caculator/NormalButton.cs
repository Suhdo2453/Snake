using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Caculator
{
    [RequireComponent(typeof(Button))]
    public class NormalButton : MonoBehaviour, IButton
    {
        public float Value { get; set; }
        
        private Button _button;
        private TMP_Text _text;
        
        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _text = GetComponentInChildren<TMP_Text>();
        }

        public void SetOnClick(Action<float> action)
        {
            if (!_button) return;
            _button.onClick.AddListener(()=>action.Invoke(Value));
        }

        public void SetText(string text)
        {
            if (!_text) return;
            _text.text = $"{text}";
        }

        public void SetValue(float value)
        {
            Value = value;
            SetText($"{value}");
        }
    }
}
