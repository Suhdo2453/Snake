using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AssetDataSO", fileName = "newDataAsset")]
public class GameAsset : ScriptableObject
{ 
    public Sprite SnakeHeadSprite;
    public Sprite SnakeBodySprite;
    public Sprite SnakeTrailSprite;
    public Sprite SpriteNguaBung;
    public Sprite SpriteGapBung;
    public Sprite DefaultSprite;
}
