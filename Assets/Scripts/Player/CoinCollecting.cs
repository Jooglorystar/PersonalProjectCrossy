using UnityEngine;
using UnityEngine.InputSystem.HID;

public class CoinCollecting : MonoBehaviour
{

    [SerializeField] private AudioClip coinClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.collectedCoin++;
            other.gameObject.SetActive(false);

            if (coinClip) SoundManager.PlayClip(coinClip);
        }
        GameManager.Instance.SetText(GameManager.Instance.coinText, GameManager.Instance.collectedCoin);
    }
}
