using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text score;
    public Text timer;
    public Text minScore;
    public Text StartCount;
    public Text round;
    public static float Count;

    // Update is called once per frame
    private void Start()
    {
        StartCount.enabled = true;
        Count = 4f;
    }
    void Update()
    {
        score.text = "Score - " + Cannon.score.ToString();
        timer.text = string.Format("{0:00.00}", Cannon.Timer) +"- Time Left";
        minScore.text = "Minimun Score to pass the level-" + Cannon.MinScore.ToString();
        StartCount.text = Mathf.Floor(Count).ToString();
        round.text = "Round " + Cannon.Round.ToString();
        Count -= Time.deltaTime;
        if(Count <= 1)
        {
            Count = 0;
            StartCount.enabled = false;
        }

        if(Cannon.Timer <= 10f)
        {
            timer.color = new Color(1f,0,0);
        }
    }
}
