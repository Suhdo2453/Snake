using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = Caculator.Input;

public partial class GameManager : MonoBehaviour
{
    [SerializeField] private Caculator.Input _input;
    [SerializeField] private GameAsset _gameAsset;
    [SerializeField] private List<GameObject> _foodPos;
    [SerializeField] private Port _port;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Sensor _loseTrigger;
    
    public static GameManager I;
    public Input Input => _input;
    public GameAsset GameAsset => _gameAsset;
    public List<GameObject> FoodPos => _foodPos;
    public Port Port => _port;
    public UIManager UIManager => _uiManager;
    public bool ColliderEnter {get; set; }
    private void Awake()
    {
        I = I ? I : this;
    }

    private void FixedUpdate()
    {
        if (_loseTrigger.IsTouch)
        {
            _uiManager.ShowHideLoseUI(true);
        }
    }

    public void RemoveFood(GameObject food)
    {
        FoodPos.Remove(food);
        Destroy(food);
    }

    public void BlockInput()
    {
        _input.BlockInput();
    }
}
