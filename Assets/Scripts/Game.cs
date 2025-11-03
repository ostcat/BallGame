using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Ball _ball;
    [SerializeField] Timer _timer;
    [SerializeField] Wallet _wallet;
    [SerializeField] CoinsHolder _coinsHolder;

    [SerializeField] string _winText = "Вы выйграли, поздравляем!";
    [SerializeField] string _looseText = "К сожалению, вы проиграли";

    private bool _isRunning = true;

    private KeyCode _restartKeyCode = KeyCode.R;

    private void Start()
    {
        _timer.ResetTimer();
        _timer.StartTimer();
    }

    private void Update()
    {
        if (Input.GetKey(_restartKeyCode))
            Restart();

        if (_isRunning == false)
            return;

        if (_isWinning())
            Win();

        if (_isLoosing())
            Loose();
    }

    private void Win()
    {
        Debug.Log(_winText);
        Stop();
    }

    private void Loose()
    {
        Debug.Log(_looseText);
        Stop();
    }

    private bool _isLoosing()
    {
        if (_timer.TimeValue <= 0 || _ball.CurrentHealth == 0)
            return true;

        else
            return false;
    }

    private bool _isWinning()
    {
        if (_wallet.CoinsNumber >= (_coinsHolder.Coins.Count))
            return true;

        else
            return false;
    }

    private void Stop()
    {
        _ball.Stop();
        _timer.Stop();
        _isRunning = false;
    }

    private void Restart()
    {
        _isRunning = true;
        _ball.Restart();
        _timer.ResetTimer();
        _timer.StartTimer();
        _wallet.Reset();

        foreach (var coin in _coinsHolder.Coins)
            coin.Reset();
    }
}