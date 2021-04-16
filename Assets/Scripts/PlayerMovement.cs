using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float turnSpeed = 20;
    
    public GameObject miniGameUI;
    public GameObject mainUI;

    private Camera cam;
    public bool hackingDist;
    public bool inGame;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        hackingDist = false;
        inGame = false;
    }

    private void Update()
    {
        if(!inGame) KeyboardMovement();

        if(hackingDist)
        {
            mainUI.transform.GetChild(0).GetComponent<Text>().text = "Objective: Press [Space] To Attempt to Hack";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mainUI.SetActive(false);
                miniGameUI.SetActive(true);
                inGame = true;
            }
        }
        else
        {
            mainUI.transform.GetChild(0).GetComponent<Text>().text = "Objective: Hack The Nearby Computer Before Time Runs Out!";
            mainUI.SetActive(true);
            miniGameUI.SetActive(false);
        }
    }

    void KeyboardMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, turnSpeed, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -turnSpeed, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
