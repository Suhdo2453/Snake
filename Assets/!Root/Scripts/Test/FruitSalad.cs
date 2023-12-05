using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FruitSalad : MonoBehaviour
{
    [Range(0, 10)] public int number;
    private void Start()
    {
        Apple apple = new Apple("Green");
    }
}
