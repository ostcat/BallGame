using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public int CoinValue { get; private set; } = 10; 
   
    public void Reset()
    {
        gameObject.SetActive(true);
    }

    public void StopCoin()
    {
        gameObject.SetActive(false);
    }
}