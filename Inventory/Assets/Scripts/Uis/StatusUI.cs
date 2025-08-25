using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : UIBase
{
    private Player player;

    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI atkText;
    [SerializeField] TextMeshProUGUI defText;
    [SerializeField] TextMeshProUGUI criticalText;

    private void Start()
    {
        player = GameManager.Instance.player;

        player.hp.OnValueChanged += UpdateHP;
        player.atk.OnValueChanged += UpdateATK;
        player.def.OnValueChanged += UpdateDEF;
        player.criticalChance.OnValueChanged += UpdateCriticalChance;

        UpdateHP(player.hp.CurValue);
        UpdateATK(player.atk.CurValue);
        UpdateDEF(player.def.CurValue);
        UpdateCriticalChance(player.criticalChance.CurValue);
    }

    void UpdateHP(float value)
    {
        hpText.text = $"체력 : {value.ToString("F1")}";
    }
    void UpdateATK(float value)
    {
        atkText.text = $"공격력 : {value.ToString("F1")}";
    }
    void UpdateDEF(float value)
    {
        defText.text = $"방어력 : {value.ToString("F1")}";
    }
    void UpdateCriticalChance(float value)
    {
        criticalText.text = $"치명타 : {value.ToString("F1")}%";
    }
    
    public void TestAddBtn()
    {
        player.hp.Add(10f);
        player.atk.Add(30f);
        player.def.Add(50f);
        player.criticalChance.Add(100f);
    }

    public void TestSubtractBtn()
    {
        player.hp.Subtract(10f);
        player.atk.Subtract(80f);
        player.def.Subtract(60f);
        player.criticalChance.Subtract(5f);
    }
}
