using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class UIManager : MonoBehaviour
{
    public TMP_Text textEarnedGolds;
    public TMP_Text textPinkGemCount;
    public TMP_Text textYellowGemCount;
    public TMP_Text textGreenGemCount;
    private GameObject player;
    private PlayerStats playerStats;
    public Color goldColor = Color.yellow;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        textPinkGemCount.text = "Pink Gems Collected: "+playerStats.pinkGemCount;
        textYellowGemCount.text = "Yellow Gems Collected: "+playerStats.yellowGemCount;
        textGreenGemCount.text = "Green Gems Collected: "+playerStats.greenGemCount;
    }

    // Update is called once per frame
    void Update()
    {
        textEarnedGolds.text="Golds Earned: ";
        textEarnedGolds.text +="<color=#"+ ColorUtility.ToHtmlStringRGB(goldColor) + ">";
        textEarnedGolds.text += playerStats.totalCash.ToString() + "</color>";
    }
}
