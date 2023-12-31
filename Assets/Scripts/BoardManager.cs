using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _snakeHead;
    [SerializeField] private Vector2 _startingCorner;
    [SerializeField] private int _width = 50;
    [SerializeField] private int _height = 40;

    private Vector2 _pos = Vector2.zero;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();

        GenerateWalls();
        InstantiateSnakeHead();
    }

    private void InstantiateSnakeHead()
    {
        GameObject snakeHead = Instantiate(_snakeHead);
        _pos = new Vector2(_startingCorner.x + (_width) /2, _startingCorner.y - (_height) /2);
        snakeHead.transform.position = _pos;

        _gameManager.AddScreenObject(snakeHead.transform);
    }

    private void GenerateWalls()
    {
        for(int i = 0; i < _height; i++)
        {
            _pos = new Vector2(_startingCorner.x, _startingCorner.y - i);
            DisplayWall(_pos);

            _pos = new Vector2(_startingCorner.x + _width, _startingCorner.y - i);
            DisplayWall(_pos);
        }

        for(int i=0; i < _width; i++)
        {
            _pos = new Vector2(_startingCorner.x + i, _startingCorner.y);
            DisplayWall(_pos);

            _pos = new Vector2(_startingCorner.x + i, _startingCorner.y - (_height - 1));
            DisplayWall(_pos);
        }
    }

    private void DisplayWall(Vector2 pos)
    {
        GameObject go = Instantiate(_wallPrefab);
        go.transform.position = pos;
        go.transform.parent = transform;

    }
}
