using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit
{
    public string className = "Warrior";
    public string playerName = "���ĸ�ź";
    public string description = "���� ����";

    private void Start()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.player = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
