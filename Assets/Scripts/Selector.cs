using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public string combo;
    
    private Vector2 offset;
    [SerializeField] private int row;
    [SerializeField] private int col;

    Phase1 minigame;
    RectTransform rect;
    
    void Start()
    {
        rect = GetComponent<RectTransform>();
        offset = new Vector2(40, 30);
        minigame = GameObject.Find("Connect").GetComponent<Phase1>();
        col = row = 0;
        GetCombo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) MoveDown();
        else if (Input.GetKeyDown(KeyCode.W)) MoveUp();
        else if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
        else if (Input.GetKeyDown(KeyCode.D)) MoveRight();
    }

    void MoveDown()
    {
        if (rect.anchoredPosition.y > -220)
        {
            rect.anchoredPosition -= new Vector2(0, offset.y);
            col++;
            GetCombo();
        }
    }

    void MoveUp()
    {
        if (rect.anchoredPosition.y < -75)
        {
            rect.anchoredPosition += new Vector2(0, offset.y);
            col--;
            GetCombo();
        }
    }

    void MoveLeft()
    {
        if (rect.anchoredPosition.x > 130)
        {
            rect.anchoredPosition -= new Vector2(offset.x, 0);
            row--;
            GetCombo();
        }

    }
    
    void MoveRight()
    {
        if (rect.anchoredPosition.x < 360)
        {
            rect.anchoredPosition += new Vector2(offset.x, 0);
            row++;
            GetCombo();
        }

    }
    
    void GetCombo()
    {
        combo = string.Empty;
        combo += minigame.nums[row, col].GetComponent<Text>().text;
        combo += minigame.nums[row+1, col].GetComponent<Text>().text;
        combo += minigame.nums[row+2, col].GetComponent<Text>().text;
        combo += minigame.nums[row+3, col].GetComponent<Text>().text;
        combo = combo.Insert(3, ".");
        combo = combo.Insert(7, ".");
    }

}
