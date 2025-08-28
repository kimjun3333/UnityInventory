using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIBase
{
    private Player player;

    [SerializeField] TextMeshProUGUI classText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] Image expBar;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI goldText;

    private void Start()
    {
        player = GameManager.Instance.player;

        player.exp.OnValueChanged += UpdateExpBar;
        player.level.OnValueChanged += UpdateLevel;
        player.gold.OnValueChanged += UpdateGold;

        UpdateClass(player.className);
        UpdateName(player.playerName);
        UpdateLevel(player.level.CurValue);
        UpdateExpBar(player.exp.CurValue);
        UpdateDescription(player.description);
        UpdateGold(player.gold.CurValue);
    }

    void UpdateClass(string value)
    {
        classText.text = $"직업 : {value}";
    }

    void UpdateName(string value)
    {
        nameText.text = $"이름 : {value}";
    }

    void UpdateLevel(float value)
    {
        levelText.text = $"레벨 : {(int)value}";
    }

    void UpdateExpBar(float value)
    {
        expText.text = $"경험치 : {value.ToString("F1")} / {player.exp.MaxValue}";
        expBar.fillAmount = value / player.exp.MaxValue;
    }

    void UpdateDescription(string value)
    {
        descriptionText.text = value;
    }

    void UpdateGold(float value)
    {
        goldText.text = $"{value}G";
    }

    public void TestAddBtn()
    {
        player.exp.Add(10f);
        player.level.Add(1);
    }

    public void TestSubtractBtn()
    {
        player.exp.Subtract(10f);
        player.level.Subtract(1);
    }
}
