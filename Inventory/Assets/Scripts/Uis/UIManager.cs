using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    [Header("UI Position")]
    public Transform topArea;
    public Transform middleArea;
    public Transform bottomArea;

    private Dictionary<UIType, GameObject> uiPrefabDict;
    private Dictionary<UIType, GameObject> instantiateUI = new();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUIPrefabsFromResources();
            foreach (UIType type in uiPrefabDict.Keys)
            {
                CreateUI(type);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadUIPrefabsFromResources() // Resources �� �ִ� UIPrefab�� ��ųʸ��� �߰����ִ� �Լ�
    {
        uiPrefabDict = new();

        GameObject[] loadedPrefabs = Resources.LoadAll<GameObject>("UIPrefabs"); // Resources�� UIPrefabs�� �ִ� ��� ������ �����´�.

        foreach(var prefab in loadedPrefabs)
        {
            UIBase uIBase = prefab.GetComponent<UIBase>();
            if(uIBase == null)
            {
                Debug.LogError($"{prefab.name}�� UIbase ������Ʈ�� �����ϴ�.");
                continue;
            }

            if(uiPrefabDict.ContainsKey(uIBase.uIType)) //�ߺ� Key����
            {
                Debug.LogError($"�ߺ��� UItype{uIBase.uIType}�� �߰ߵǾ� �����մϴ�.");
                continue;
            }

            uiPrefabDict.Add(uIBase.uIType, prefab); // UIBase�� �ְ� ������ Key(UiType)�� ���� ��ųʸ��� uiprefabDic�� �߰�
        }
        Debug.Log($"UI ������ {uiPrefabDict.Count}�� ��ϿϷ�."); // ��Ͻ�Ų UI�� ������ üũ
    }

    public GameObject CreateUI(UIType uiType)
    {
        if(!uiPrefabDict.TryGetValue(uiType, out GameObject prefab))
        {
            Debug.Log($"UIType {uiType}�� �ش��ϴ� �������� �����ϴ�.");
            return null;
        }

        GameObject instance = Instantiate(prefab); // �������� �ν��Ͻ�ȭ(���� ����)�Ѵ�.

        UIBase uiBase = instance.GetComponent<UIBase>();
        Transform parent; // ��ġ ���� ����

        switch (uiBase.layerType)
        {
            case LayerType.Top:
                parent = topArea;
                break;

            case LayerType.Middle:
                parent = middleArea;
                break;

            case LayerType.Bottom:
                parent = bottomArea;
                break;

            default:
                parent = bottomArea;
                break;
        }

        instance.transform.SetParent(parent, false); // instance�� �θ� ������ ���� parent�� ����. False�� ���� ��ǥ�� �ƴ� *������ǥ*�� �����ϰڴٴ� �ǹ�

        if (!instantiateUI.ContainsKey(uiType))
        {
            instantiateUI.Add(uiType, instance);
        }
        else
        {
            Debug.LogError($"{uiType} UI�� �̹� �����Ǿ� �ֽ��ϴ�.");
        }

        return instance; //������ �ν��Ͻ� ��ȯ
    }

    public void OpenUI(UIType type)
    {
        if(instantiateUI.TryGetValue(type, out GameObject ui) && ui != null)
        {
            ui.SetActive(true);
        }
    }

    public void CloseUI(UIType type)
    {
        if (instantiateUI.TryGetValue(type, out GameObject ui) && ui != null)
        {
            ui.SetActive(false);
        }
    }

    private void OnEnable()
    {
        UIEventSystem.OnRequestOpenUI += OpenUI;
        UIEventSystem.OnRequestCloseUI += CloseUI;
    }

    private void OnDisable()
    {
        UIEventSystem.OnRequestOpenUI -= OpenUI;
        UIEventSystem.OnRequestCloseUI -= CloseUI;
    }
}   
