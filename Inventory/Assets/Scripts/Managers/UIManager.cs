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

    void LoadUIPrefabsFromResources() // Resources 에 있는 UIPrefab을 딕셔너리에 추가해주는 함수
    {
        uiPrefabDict = new();

        GameObject[] loadedPrefabs = Resources.LoadAll<GameObject>("UIPrefabs"); // Resources의 UIPrefabs에 있는 모든 파일을 가져온다.

        foreach(var prefab in loadedPrefabs)
        {
            UIBase uIBase = prefab.GetComponent<UIBase>();
            if(uIBase == null)
            {
                Debug.LogError($"{prefab.name}에 UIbase 컴포넌트가 없습니다.");
                continue;
            }

            if(uiPrefabDict.ContainsKey(uIBase.uIType)) //중복 Key무시
            {
                Debug.LogError($"중복된 UItype{uIBase.uIType}가 발견되어 무시합니다.");
                continue;
            }

            uiPrefabDict.Add(uIBase.uIType, prefab); // UIBase가 있고 고유의 Key(UiType)를 가진 딕셔너리를 uiprefabDic에 추가
        }
        Debug.Log($"UI 프리팹 {uiPrefabDict.Count}개 등록완료."); // 등록시킨 UI의 갯수를 체크
    }

    public GameObject CreateUI(UIType uiType)
    {
        if(!uiPrefabDict.TryGetValue(uiType, out GameObject prefab))
        {
            Debug.Log($"UIType {uiType}에 해당하는 프리팹이 없습니다.");
            return null;
        }

        GameObject instance = Instantiate(prefab); // 프리팹을 인스턴스화(씬에 생성)한다.

        UIBase uiBase = instance.GetComponent<UIBase>();
        Transform parent; // 위치 변수 선언

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

        instance.transform.SetParent(parent, false); // instance의 부모를 위에서 정한 parent로 설정. False는 월드 좌표가 아닌 *로컬좌표*로 유지하겠다는 의미

        if (!instantiateUI.ContainsKey(uiType))
        {
            instantiateUI.Add(uiType, instance);
        }
        else
        {
            Debug.LogError($"{uiType} UI가 이미 생성되어 있습니다.");
        }

        return instance; //생성한 인스턴스 반환
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
