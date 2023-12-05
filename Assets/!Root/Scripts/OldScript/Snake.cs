using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Input = Caculator.Input;

public class Snake : MonoBehaviour
{
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    }

    private Input _input;
    private GameAsset _gameAsset;

    private SpriteRenderer _renderer;
    private Vector2 _moveDirection;
    private List<BodyPart> _bodyParts = new();
    private Vector2 _headPosBefore;
    private Vector3 _headRotation;
    private Vector2 pos;
    private bool _canMove = true;
    private int _bodySize;
    
    [SerializeField] private Direction _direction = Direction.DOWN;
    [SerializeField] private BodyPart _bodyPart;
    [SerializeField] private GameObject _parent;
    [SerializeField] private LayerMask _groundLayer;

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
    
    private void Start()
    {
        _input = GameManager.I.Input;
        _gameAsset = GameManager.I.GameAsset;
        _bodySize = Config.BODY_SIZE;

        _renderer = GetComponent<SpriteRenderer>();

        SetDirection(_direction);
        SetHeadSprite();
        FlipFace();
        DrawBodyInStart();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GameManager.I.ColliderEnter) return;
        if (_input.GetKeyUp && _moveDirection != Vector2.down && _canMove)
        {
            _headPosBefore = transform.position;
            pos = new Vector2(_headPosBefore.x, _headPosBefore.y + 1);
            SetDirection(Direction.UP);
            if (!CheckCanMove(pos)) return;
            _canMove = false;
            CheckFood(pos);
            CheckWinGame(pos);
            transform.DOMove(pos, Config.MOVE_SPEED).SetEase(Ease.Linear).OnComplete(()=> _canMove = true);
            FlipFace();
            DrawBody();
            //SetSpriteBody();
            return;
        }

        if (_input.GetKeyDown && _moveDirection != Vector2.up &&  _canMove)
        {
            _headPosBefore = transform.position;
            pos = new Vector2(_headPosBefore.x, _headPosBefore.y - 1);
            SetDirection(Direction.DOWN);
            if (!CheckCanMove(pos)) return;
            _canMove = false;
            CheckFood(pos);
            CheckWinGame(pos);
            transform.DOMove(pos, Config.MOVE_SPEED).SetEase(Ease.Linear).OnComplete(()=> _canMove = true);
            FlipFace();
            DrawBody();
            //SetSpriteBody();
            return;
        }

        if (_input.GetKeyLeft && _moveDirection != Vector2.right &&  _canMove)
        {
            _headPosBefore = transform.position;
            pos = new Vector2(_headPosBefore.x - 1, _headPosBefore.y);
            SetDirection(Direction.LEFT);
            if (!CheckCanMove(pos)) return;
            _canMove = false;
            CheckFood(pos);
            CheckWinGame(pos);
            transform.DOMove(pos, Config.MOVE_SPEED).SetEase(Ease.Linear).OnComplete(()=> _canMove = true);
            FlipFace();
            DrawBody();
            //SetSpriteBody();
            return;
        }

        if (_input.GetKeyRight && _moveDirection != Vector2.left &&  _canMove)
        {
            _headPosBefore = transform.position;
            pos = new Vector2(_headPosBefore.x + 1, _headPosBefore.y);new Vector2(_headPosBefore.x + 1, _headPosBefore.y);
            SetDirection(Direction.RIGHT);
            if (!CheckCanMove(pos)) return;
            _canMove = false;
            CheckFood(pos);
            CheckWinGame(pos);
            transform.DOMove(pos, Config.MOVE_SPEED).SetEase(Ease.Linear).OnComplete(()=> _canMove = true);
            FlipFace();
            DrawBody();
            //SetSpriteBody();
            return;
        }
    }

    private void FlipFace()
    {
        if (_moveDirection == Vector2.up)
        {
            _headRotation = new Vector3(0, 0, 180);
            transform.DORotate(_headRotation, Config.MOVE_SPEED);
            return;
        }

        if (_moveDirection == Vector2.down)
        {
            _headRotation = new Vector3(0, 0, 0);
            transform.DORotate(_headRotation, Config.MOVE_SPEED);
            return;
        }

        if (_moveDirection == Vector2.left)
        {
            _headRotation = new Vector3(0, 0, -90);
            transform.DORotate(_headRotation, Config.MOVE_SPEED);
            return;
        }

        if (_moveDirection == Vector2.right)
        {
            _headRotation = new Vector3(0, 0, 90);
            transform.DORotate(_headRotation, Config.MOVE_SPEED);
            return;
        }
    }

    private void SetHeadSprite()
    {
        if (_renderer == null) return;
        _renderer.sprite = _gameAsset.SnakeHeadSprite;
    }

    private void SetDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                _moveDirection = Vector2.up;
                _direction = Direction.UP;
                break;
            case Direction.DOWN:
                _moveDirection = Vector2.down;
                _direction = Direction.DOWN;
                break;
            case Direction.LEFT:
                _moveDirection = Vector2.left;
                _direction = Direction.LEFT;
                break;
            case Direction.RIGHT:
                _moveDirection = Vector2.right;
                _direction = Direction.RIGHT;
                break;
        }
    }

    private void DrawBodyInStart()
    {
        if (_bodyParts.Count <= 0)
        {
            for (int i = 0; i < _bodySize; i++)
            {
                if (i == 0)
                {
                    var position = CalculatePosition(transform.position);
                    var bodyPart = CreateBodyPart(position);
                    _bodyParts.Add(bodyPart);
                    bodyPart.SetDefaultDir(_direction);
                    bodyPart.Rotate(_headRotation);
                    bodyPart.SetSprite(_direction);
                }
                else
                {
                    var position = CalculatePosition(_bodyParts[i - 1].transform.position);
                    var bodyPart = CreateBodyPart(position);
                    _bodyParts.Add(bodyPart);
                    bodyPart.SetDefaultDir(_direction);
                    bodyPart.Rotate(_headRotation);
                    bodyPart.SetSprite(_direction, i == _bodySize - 1);
                }
            }
        }
    }

    private void DrawBody()
    {
        if (_bodyParts.Count <= 0) return;
        Vector2 posBodyPartBefore = Vector2.zero;
        Vector3 rotationBefore = _headRotation;
        var typeBefore = BodyPartType.None;
        var dirBefore = _direction;
        for (int i = 0; i < _bodySize; i++)
        {
            if (i == 0)
            {
                posBodyPartBefore = _bodyParts[i].transform.position;
                _bodyParts[i].name = $"Body Part at {_headPosBefore.ToString()}";
                _bodyParts[i].transform.DOMove(_headPosBefore, Config.MOVE_SPEED).SetEase(Ease.Linear);
                
                rotationBefore = _bodyParts[i].transform.rotation.eulerAngles;
                _bodyParts[i].Rotate(_headRotation);
                dirBefore = _bodyParts[i].Direction;
                _bodyParts[i].SetSprite(_direction);
            }
            else if (i >= _bodyParts.Count)
            {
                var bodyPart = CreateBodyPart(posBodyPartBefore);
                _bodyParts.Add(bodyPart);
                bodyPart.Rotate(rotationBefore);
                bodyPart.SetSprite(dirBefore, true);
            }
            else
            {
                var _tempPos = posBodyPartBefore;
                var _tempRotate = rotationBefore;
                var _tempDir = dirBefore;
                posBodyPartBefore = _bodyParts[i].transform.position;
                _bodyParts[i].transform.DOMove(_tempPos, Config.MOVE_SPEED).SetEase(Ease.Linear);
                _bodyParts[i].name = $"Body Part at {_tempPos.ToString()}";
                
                rotationBefore = _bodyParts[i].transform.rotation.eulerAngles;
                _bodyParts[i].Rotate(_tempRotate);
                dirBefore = _bodyParts[i].Direction;
                _bodyParts[i].SetSprite(_tempDir, i == _bodySize - 1);
            }
        }
    }

    private BodyPart CreateBodyPart(Vector2 position)
    {
        var body = Instantiate(_bodyPart, _parent.transform);
        body.name = $"Body Part at {position.ToString()}";
        body.transform.position = position;
        return body;
    }

    private Vector2 CalculatePosition(Vector2 position)
    {
        switch (_direction)
        {
            case Direction.UP:
                return new Vector2(position.x, position.y - 1);
            case Direction.DOWN:
                return new Vector2(position.x, position.y + 1);
            case Direction.LEFT:
                return new Vector2(position.x + 1, position.y);
            case Direction.RIGHT:
                return new Vector2(position.x - 1, position.y);
            default:
                return Vector2.zero;
        }
    }

    private bool CheckCanMove(Vector2 position)
    {
        var result = Physics2D.Raycast(transform.position, (position - (Vector2)transform.position).normalized, 0.6f, _groundLayer);
        return !result;
    }

    private void CheckFood(Vector2 pos)
    {
        foreach (var food in GameManager.I.FoodPos)
        {
            if (CompareVectors(pos, food.transform.position))
            {
                EatFood(food);
                return;
            }
        }
    }

    private void CheckWinGame(Vector2 pos)
    {
        if (CompareVectors(pos, GameManager.I.Port.transform.position))
        {
            //show UI win game
            GameManager.I.Port.DisableCollider();
            GameManager.I.UIManager.ShowHideWinUI(true);
            GameManager.I.BlockInput();
        }
    }

    private void EatFood(GameObject food)
    {
        _bodySize++;
        GameManager.I.RemoveFood(food);
    }

    private float epsilon = 0.5f;
    private bool CompareVectors(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b) < epsilon;
    }
}