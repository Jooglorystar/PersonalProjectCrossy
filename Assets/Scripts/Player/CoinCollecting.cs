using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    public LayerMask layerMask;

    public void CollectCoin(Vector3 moveInput)
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.z).normalized;

        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), moveDir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1f, layerMask))
        {
            GameManager.Instance.CollectedCoin++;
            hit.collider.gameObject.SetActive(false);
        }
    }
}
