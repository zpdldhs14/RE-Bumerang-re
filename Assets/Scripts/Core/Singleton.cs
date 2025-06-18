using UnityEngine;

/// <summary>
/// 싱글톤 패턴을 구현하는 제네릭 기본 클래스입니다.
/// </summary>
/// <typeparam name="T">싱글톤으로 구현할 클래스 타입</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// 싱글톤 인스턴스입니다.
    /// </summary>
    private static T instance;

    /// <summary>
    /// 싱글톤이 초기화되었는지 여부를 나타냅니다.
    /// </summary>
    private static bool isInitialized = false;

    /// <summary>
    /// 싱글톤 인스턴스에 접근하기 위한 프로퍼티입니다.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (!isInitialized)
            {
                Debug.LogError($"[Singleton] {typeof(T).Name}이(가) 초기화되지 않았습니다.");
                return null;
            }
            return instance;
        }
    }

    /// <summary>
    /// Awake에서 싱글톤 인스턴스를 초기화합니다.
    /// </summary>
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            isInitialized = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning($"[Singleton] {typeof(T).Name}의 중복 인스턴스가 생성되었습니다. 기존 인스턴스를 유지합니다.");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// OnDestroy에서 싱글톤 인스턴스를 정리합니다.
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            isInitialized = false;
            instance = null;
        }
    }
} 