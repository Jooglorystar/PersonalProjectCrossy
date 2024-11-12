using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;        // ����
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance; // ��ġ�� ������

    private void Awake()
    {
        instance = this;
    }

    public static void PlayClip(AudioClip clip)
    {
        // ������Ʈ Ǯ���� ��������
        GameObject obj = GameManager.Instance.objectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, Instance.soundEffectVolume, Instance.soundEffectPitchVariance);
    }
}
