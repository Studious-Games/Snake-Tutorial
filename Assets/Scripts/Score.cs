using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _score;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        _score.text = _gameManager.Score.ToString();
    }

}
