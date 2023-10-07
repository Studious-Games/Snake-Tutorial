using System;
using System.Collections;

using TMPro;

using Unity.VisualScripting;

using UnityEngine;

public class FoodCountdown : MonoBehaviour
{
    [SerializeField] private int _countdownTimer = 9;
    [SerializeField] private TextMeshPro _countdownText;

    private GameManager _gameManager;

    public int CountdownTimer { get => _countdownTimer; set => _countdownTimer = value; }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        if (_gameManager.CurrentState != GameState.GameInProgress)
            return;

        StartCoroutine(Countdown());
    }

    private void Update()
    {
        _countdownText.text = CountdownTimer.ToString();        
    }

    IEnumerator Countdown()
    {
        while(CountdownTimer >= 0)
        {
            yield return new WaitForSeconds(1);
            CountdownTimer--;

            if (_gameManager.CurrentState != GameState.GameInProgress)
                break;
        }

        _gameManager.RemoveScreenObject(transform);
        Destroy(gameObject);
    }
}
