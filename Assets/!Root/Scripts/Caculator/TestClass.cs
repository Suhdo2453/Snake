using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Caculator
{
    public class TestClass : MonoBehaviour
    {
        public Button btn;
        [Inject] private readonly ICaculatorLogic _caculatorLogic;
        [Inject] private readonly ICaculatorController _controller;

        private void Awake()
        {
            btn = GetComponent<Button>();
        }

        private void Start()
        {
            btn.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            
            _controller.DisplayResults(_caculatorLogic.Addition(2, 3));
        }
    }
}
