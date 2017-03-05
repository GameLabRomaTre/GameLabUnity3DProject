using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text score;

    public void SetScore(int score)
    {
        this.score.text = score.ToString();
    }
}
