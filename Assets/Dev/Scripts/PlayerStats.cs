using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float totalCash = 0;
    public int pinkGemCount = 0;
    public int yellowGemCount=0;
    public int greenGemCount=0;

    private void Start()
    {
        LoadPlayerData();
    }
    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
    private void SavePlayerData()
    {
        PlayerPrefs.SetFloat("TotalCash", totalCash);
        PlayerPrefs.SetInt("PinkGemCount", pinkGemCount);
        PlayerPrefs.SetInt("YellowGemCount", yellowGemCount);
        PlayerPrefs.SetInt("GreenGemCount", greenGemCount);
        PlayerPrefs.Save();
    }
    private void LoadPlayerData()
    {
        totalCash = PlayerPrefs.GetFloat("TotalCash", 0);
        pinkGemCount = PlayerPrefs.GetInt("PinkGemCount", 0);
        yellowGemCount = PlayerPrefs.GetInt("YellowGemCount", 0);
        greenGemCount = PlayerPrefs.GetInt("GreenGemCount", 0);
    }
    public void RecalculateMoney(float price)
    {
        totalCash += price;
        totalCash=Mathf.Round(totalCash);
    }
}
