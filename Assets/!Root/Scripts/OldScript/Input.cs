using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caculator
{
    public class Input : MonoBehaviour
    {
        public bool GetKeyUp { get; private set; }
        public bool GetKeyDown { get; private set; }
        public bool GetKeyLeft { get; private set; }
        public bool GetKeyRight { get; private set; }
    
        private bool _blockInput;
    
        private void Start()
        {
            _blockInput = false;
        }
    
        private void Update()
        {
            if (_blockInput) return;
            SetKeyUp();
            SetKeyDown();
            SetKeyLeft();
            SetKeyRight();
        }
    
        public void BlockInput()
        {
            _blockInput = true;
            GetKeyUp = false;
            GetKeyDown = false;
            GetKeyLeft = false;
            GetKeyRight = false;
        }
    
        private void SetKeyUp()
        {
            GetKeyUp = UnityEngine.Input.GetKeyDown(KeyCode.UpArrow);
        }
        
        private void SetKeyDown()
        {
            GetKeyDown = UnityEngine.Input.GetKeyDown(KeyCode.DownArrow);
        }
        
        private void SetKeyLeft()
        {
            GetKeyLeft = UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow);
        }
        
        private void SetKeyRight()
        {
            GetKeyRight = UnityEngine.Input.GetKeyDown(KeyCode.RightArrow);
        }
    }
}