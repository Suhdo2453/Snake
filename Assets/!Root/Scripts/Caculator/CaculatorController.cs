using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Caculator
{
    public class CaculatorController : IStartable, ICaculatorController
    {
        private readonly ICaculatorLogic _caculatorLogic;
        private readonly CaculatorView _caculatorView;

        private TMP_InputField _forcusInput;
        
        public CaculatorController(ICaculatorLogic caculatorLogic, CaculatorView caculatorView)
        {
            _caculatorLogic = caculatorLogic;
            _caculatorView = caculatorView;
        }

        public void Start()
        {
            _caculatorView._AdditionButton.onClick.AddListener(OnAdditionButtonClick);
            _caculatorView._SubtractionButton.onClick.AddListener(OnSubtractionButtonClick);
            _caculatorView._DivisionButton.onClick.AddListener(OnDivisionButtonClick);
            _caculatorView._MultiplicationButton.onClick.AddListener(OnMultiplicationButtonClick);
            _caculatorView._TextA.onSelect.AddListener(OnFocusInputField);
            _caculatorView._TextB.onSelect.AddListener(OnFocusInputField);

            for (int i = 0; i < _caculatorView._NormalButtons.Length; i++)
            {
                _caculatorView._NormalButtons[i].SetValue(i);
                _caculatorView._NormalButtons[i].SetOnClick(OnNormalButtonClick);
            }
        }

        public void DisplayResults(float result)
        {
            _caculatorView._TextResults.text = $"{result}";
        }

        public void UpdateText(string text)
        {
            _caculatorView._TextResults.text += $" {text}";
        }

        public void OnAdditionButtonClick()
        {
            var a = float.Parse(_caculatorView._TextA.text);
            var b = float.Parse(_caculatorView._TextB.text);
            if (float.IsNaN(a) || float.IsNaN(b)) return;
            var result =_caculatorLogic.Addition(a, b);
            DisplayResults(result);
        }

        public void OnSubtractionButtonClick()
        {
            var a = float.Parse(_caculatorView._TextA.text);
            var b = float.Parse(_caculatorView._TextB.text);
            if (float.IsNaN(a) || float.IsNaN(b)) return;
            var result =_caculatorLogic.Subtraction(a, b);
            DisplayResults(result);
        }

        public void OnMultiplicationButtonClick()
        {
            var a = float.Parse(_caculatorView._TextA.text);
            var b = float.Parse(_caculatorView._TextB.text);
            if (float.IsNaN(a) || float.IsNaN(b)) return;
            var result =_caculatorLogic.Multiplication(a, b);
            DisplayResults(result);
        }

        public void OnDivisionButtonClick()
        {
            var a = float.Parse(_caculatorView._TextA.text);
            var b = float.Parse(_caculatorView._TextB.text);
            if (float.IsNaN(a) || float.IsNaN(b)) return;
            var result =_caculatorLogic.Division(a, b);
            DisplayResults(result);
        }

        public void OnNormalButtonClick(float value)
        {
            if(_forcusInput != null)
                _forcusInput.text += $"{value}";
        }

        public void OnFocusInputField(string arg0)
        {
            _forcusInput = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>();
        }
    }
}