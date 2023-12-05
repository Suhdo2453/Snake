using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Fruit
{
    public Apple()
    {
        color = "red";
        Debug.Log("1st Apple Constructor Called");
    }

    public Apple(string newColor) : base(newColor)
    {
        Debug.Log("2nd Apple Constructor Called");
    }
}
