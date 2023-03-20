using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager UIinstance
    {

        get
        {
            if (instance != null)
            {
                Debug.Log("ui manager is null");
            }
            return instance;
        }
    }
    public TextMeshProUGUI playerGemCountText;

    public Image selectionImg;

    public TextMeshProUGUI gemCount;

    public Image[] healthBars;


    private void Awake()
    {
        instance = this;

    }
    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
        
    }
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = " "+gemCount.ToString()+"G";
    }
    public void UpdateGemCount(int count)
    {
        gemCount.text = " " + count;
    }
    public void UpdateHealthBar(int lives)
    {
        for (int i = 0; i <= lives; i++)
        {
            if (i == lives)
            {
                healthBars[i].enabled = false;
            }
        }
    }
}
