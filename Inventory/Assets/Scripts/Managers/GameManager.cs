using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public ItemDataBase itemDataBase;

    public Player player;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            player.AddItem(itemDataBase.itemLists[0]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            player.AddItem(itemDataBase.itemLists[1]);
        }
    }
}
