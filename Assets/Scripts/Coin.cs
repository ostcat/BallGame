using UnityEngine;

public class Coin : MonoBehaviour
{
    [field: SerializeField] public int CoinValue { get; private set; } = 10; 
   
    public void Reset()
    {
        gameObject.SetActive(true);
    }

    public void Collect()
    {
        gameObject.SetActive(false);
    }
}