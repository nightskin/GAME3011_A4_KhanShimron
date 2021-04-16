using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    [SerializeField] private float totalTime;

    public bool active;
    [Range(0,59)]

    private Text timerTxt;
    private float interval;
    private int min;
    private int sec;

    void Start()
    {
        active = true;
        interval = 1;
        timerTxt = GetComponent<Text>();
        if(Menus.instance.diff == Menus.Difficulty.EASY)
        {
            min = 5;
        }
        else if(Menus.instance.diff == Menus.Difficulty.NORMAL)
        {
            min = 3;
        }
        else if(Menus.instance.diff == Menus.Difficulty.HARD)
        {
            min = 1;
        }
        SetTime();
        
    }

    void SetTime()
    {
        totalTime += min * 60;
        totalTime += sec;
        timerTxt.text = min.ToString() + ":" + sec.ToString();
        if(sec < 10)
        {
           timerTxt.text = min.ToString() + ":0" + sec.ToString();
        }
    }
   
    void CountDown()
    {
        if (active)
        {
            if (sec <= 0)
            {
                min--;
                sec = 59;
            }
            else
            {
                sec--;
            }

            if (sec < 10)
            {
                timerTxt.text = min.ToString() + ":0" + sec.ToString();
            }
            else
            {
                timerTxt.text = min.ToString() + ":" + sec.ToString();
            }
        }
    }
    
    void Update()
    {
        interval -= Time.deltaTime;
        if(interval <= 0)
        {
            CountDown();
            interval = 1;
            if (timerTxt.text == "0:00")
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
