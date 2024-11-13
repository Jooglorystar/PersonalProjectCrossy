using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            particle.Play();
            GameManager.Instance.gameOverPanel.gameObject.SetActive(true);
        }
    }
}
