using UnityEngine;
using UnityEngine.UI;

public class Phase1 : MonoBehaviour
{
    public GameObject Numbers;
    public GameObject Num2; //Text UI object with 3 numbers
    public Door door;

    public Text IpTxt;
    public Image Selector;
    public GameObject[,] nums;
    public Light alarmLight;
    public Timer timer;
    public GameObject objective;
    

    public int rows = 6; // >= 4

    public Vector2 offset;

    private int cols;
    private string neededIp; //12 numbers 3x4
    private Selector selector;
    private PlayerMovement player;

    

    void Start()
    {
        cols = transform.Find("Numbers").GetComponent<GridLayoutGroup>().constraintCount;
        nums = new GameObject[cols, rows];
        selector = GameObject.Find("Selector").GetComponent<Selector>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        SetupGame();
    }

    void SetupGame()
    {
        for (int i = 0; i < 8; i++)
        {
            int r = Random.Range(1, 10);
            neededIp += r.ToString();
            if (i == 2 || i == 5) neededIp += ".";
        }
        IpTxt.text = "Find Network To Use Hacking Device - IP: " + neededIp;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                var num = Instantiate(Num2, Numbers.transform);
                num.name = x.ToString() + "," + y.ToString();
                int r1 = Random.Range(1, 10);
                int r2 = Random.Range(1, 10);
                num.GetComponent<Text>().text += r1.ToString();
                num.GetComponent<Text>().text += r2.ToString();
                nums[x, y] = num;
            }
        }

        PlaceIP();
    }

    void PlaceIP()
    {
        int r = Random.Range(0, rows - 5);
        int c = Random.Range(0, cols - 5);
        string ipMod = neededIp;
        ipMod = ipMod.Replace(".","");
        string set0 = ipMod;
        string set1 = ipMod;
        string set2 = ipMod;
        string set3 = ipMod;
        
        set0 = set0.Remove(2);
        nums[r, c].GetComponent<Text>().text = set0;
        set1 = set1.Remove(0, 2);
        set1 = set1.Remove(2);
        nums[r+1, c].GetComponent<Text>().text = set1;
        set2 = set2.Remove(0,2);
        set2 = set2.Remove(0, 2);
        set2 = set2.Remove(2);
        nums[r+2, c].GetComponent<Text>().text = set2;
        set3 = set3.Remove(0, 2);
        set3 = set3.Remove(0, 2);
        set3 = set3.Remove(0, 2);
        nums[r+3, c].GetComponent<Text>().text = set3;
    }

    public void CheckMatch()
    {
        if(neededIp == selector.combo)
        {
            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.Find("Main UI").gameObject.SetActive(true);
            player.inGame = false;

            alarmLight.color = new Color(0, 1, 1);
            timer.active = false;
            door.locked = false;
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            transform.parent.parent.Find("Main UI").gameObject.SetActive(true);
            player.inGame = false;
        }
    }

    public void GiveUp()
    {
        transform.parent.gameObject.SetActive(false);
        transform.parent.parent.Find("Main UI").gameObject.SetActive(true);
        player.inGame = false;
    }

    
}
