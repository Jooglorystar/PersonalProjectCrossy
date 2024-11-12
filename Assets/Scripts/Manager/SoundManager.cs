using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;        // 볼륨
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance; // 피치값 변조용

    private void Awake()
    {
        instance = this;
    }

    public static void PlayClip(AudioClip clip)
    {
        // 오브젝트 풀에서 가져오기
        GameObject obj = GameManager.Instance.objectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, Instance.soundEffectVolume, Instance.soundEffectPitchVariance);
    }
}
