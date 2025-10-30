using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Ball _ball;
    [SerializeField] Timer _timer;
    [SerializeField] Wallet _wallet;
    [SerializeField] string _winText = "Вы выйграли, поздравляем!";
    [SerializeField] string _looseText = "К сожалению, вы проиграли";
    [SerializeField] List<Coin> _coins;

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

        if (_wallet.CoinsNumber >= (_coins.Count))
            Win();

        if (_timer.TimeValue <= 0)
            Loose();

        if (_ball.CurrentHealth == 0)
            Loose();
    }

    private void Win()
    {
        Debug.Log(_winText);
        _ball.Stop();
        _timer.Stop();
    }

    private void Loose()
    {
        Debug.Log(_looseText);
        _timer.Stop();
        _ball.Stop();
    }

    private void Restart()
    {
        _ball.Restart();
        _timer.ResetTimer();
        _timer.StartTimer();
        _wallet.Reset();

        foreach (var coin in _coins)
            coin.Reset();
    }
}