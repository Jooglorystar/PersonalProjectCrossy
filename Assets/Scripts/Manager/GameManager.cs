using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }


    public TextMeshProUGUI coinText;
    public TextMeshProUGUI TimeText;

    public PlayerController Player;

    public int collectedCoin = 0;
    public int timeScore = 0;

    public bool isPlaying = true;

    private Coroutine timeScoreCoroutine;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SetText(coinText, collectedCoin);
        SetText(TimeText, timeScore);
        StartCoroutine(DisplayTimeScore());
    }

    public void SetText(TextMeshProUGUI text, int value)
    {
        text.text = value.ToString();
    }

    private IEnumerator DisplayTimeScore()
    {
        while(isPlaying)
        {
            yield return new WaitForSeconds(2f);
            timeScore++;
            SetText(TimeText, timeScore);
        }
    }
}
