using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIEventSystem
{
    public static event Action<UIType> OnRequestOpenUI; //특정 UI를 열어달라고 요청하는 이벤트 (구독가능)
    public static event Action<UIType> OnRequestCloseUI;

    public static void RequestOpenUI(UIType type) //위 이벤트를 외부에서 호출할수있는 함수
    {
        OnRequestOpenUI?.Invoke(type); // 이벤트에 구독된 함수가 있다면 실행
    }

    public static void RequestCloseUI(UIType type)
    {
        OnRequestCloseUI?.Invoke(type);
    }
}
