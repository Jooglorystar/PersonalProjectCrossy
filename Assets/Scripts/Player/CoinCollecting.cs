using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    public LayerMask layerMask;

    [SerializeField] private AudioClip coinClip;
    public void CollectCoin(Vector3 moveInput)
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.z).normalized;

        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), moveDir);
        RaycastHit hit;

        // 앞에 위치하는 것이 Coin인지 판단.
        if (Physics.Raycast(ray, out hit, 1f, layerMask))
        {
            GameManager.Instance.collectedCoin++;
            hit.collider.gameObject.SetActive(false);

            if(coinClip) SoundManager.PlayClip(coinClip);
        }

        GameManager.Instance.SetText(GameManager.Instance.coinText, GameManager.Instance.collectedCoin);
    }
}
