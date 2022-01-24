using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }
}
