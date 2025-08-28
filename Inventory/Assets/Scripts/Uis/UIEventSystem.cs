using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIEventSystem
{
    public static event Action<UIType> OnRequestOpenUI; //Ư�� UI�� ����޶�� ��û�ϴ� �̺�Ʈ (��������)
    public static event Action<UIType> OnRequestCloseUI;

    public static void RequestOpenUI(UIType type) //�� �̺�Ʈ�� �ܺο��� ȣ���Ҽ��ִ� �Լ�
    {
        OnRequestOpenUI?.Invoke(type); // �̺�Ʈ�� ������ �Լ��� �ִٸ� ����
    }

    public static void RequestCloseUI(UIType type)
    {
        OnRequestCloseUI?.Invoke(type);
    }
}
