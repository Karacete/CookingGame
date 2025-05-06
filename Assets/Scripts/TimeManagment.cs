using TMPro;
using UnityEngine;

public class TimeManagment : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private int score = 100;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI sureText;
    public void IncreaseTime(float amount)
    {
        time += amount;
        timeText.text = time.ToString();
    }
    public void DoubleScore()
    {
        // if (time > 27)
        // {
        //     for (int i = 0; i < time - 27; i++)
        //     {
        //         score -= 8;
        //         if (score < 0)
        //             score = 0;
        //     }
        // }
        // else
        //     score = 100;
        scorePanel.SetActive(true);
        sureText.text = timeText.text;
        //scoreText.text = score.ToString();
    }
    public void TrippleScore()
    {
        // if (time > 25)
        // {
        //     for (int i = 0; i < time - 25; i++)
        //     {
        //         score -= 10;
        //         if (score < 0)
        //             score = 0;
        //     }
        // }
        // else
        //     score = 100;
        scorePanel.SetActive(true);
        sureText.text = timeText.text;
        //scoreText.text = score.ToString();
    }
}
