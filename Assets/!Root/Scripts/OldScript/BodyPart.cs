using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum BodyPartType
{
    Normal,
    Trail,
    Angle,
    None
}

public class BodyPart : MonoBehaviour
{
    public Sprite Sprite { get; private set; }
    public BodyPartType ThisType {get; private set; }
    public Snake.Direction Direction {get; private set; }
    
    private Vector2 _position;
    
    [SerializeField]
    private SpriteRenderer _renderer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.I.ColliderEnter = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(!GameManager.I.ColliderEnter)
            GameManager.I.ColliderEnter = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        GameManager.I.ColliderEnter = false;
    }

    public void SetDefaultDir( Snake.Direction direction)
    {
        Direction = direction;
    }
    
    public void Rotate(Vector3 rotation)
    {
        transform.DORotate(rotation, 0.05f);
    }

    public void SetSprite(Snake.Direction direction, bool isTrail = false)
    {
        if (isTrail)
        {
            _renderer.sprite = GameManager.I.GameAsset.SnakeTrailSprite;
            Direction = direction;
            return;
        }
        
        if (direction == Direction)
        {
            _renderer.sprite = GameManager.I.GameAsset.DefaultSprite;
            return;
        }

        switch (direction)
        {
            case Snake.Direction.UP:
                if (Direction is Snake.Direction.LEFT)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteGapBung;
                if (Direction is Snake.Direction.RIGHT)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteNguaBung;
                break;
            case Snake.Direction.DOWN:
                if (Direction is Snake.Direction.LEFT)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteNguaBung;
                if (Direction is Snake.Direction.RIGHT)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteGapBung;
                break;
            case Snake.Direction.LEFT:
                if (Direction is Snake.Direction.UP)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteNguaBung;
                if (Direction is Snake.Direction.DOWN)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteGapBung;
                break;
            case Snake.Direction.RIGHT:
                if (Direction is Snake.Direction.UP)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteGapBung;
                if (Direction is Snake.Direction.DOWN)
                    _renderer.sprite = GameManager.I.GameAsset.SpriteNguaBung;
                break;
        }
        Direction = direction;
    }
}
