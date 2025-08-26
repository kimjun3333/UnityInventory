using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private UIType targetUI;

    private bool isOpen = false;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (!isOpen)
            {
                UIEventSystem.RequestOpenUI(targetUI);
            }
            else
            {
                UIEventSystem.RequestCloseUI(targetUI);
            }
            isOpen = !isOpen;
        });
    }
}
