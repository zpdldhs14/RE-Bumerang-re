using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] protected string interactType;
    [SerializeField] protected GameObject uiObject;
    
    protected virtual void Awake()
    {
        // 기본 초기화 로직이 필요한 경우 여기에 작성
    }

    public virtual void Interact()
    {
        if (uiObject != null)
        {
            UIManager.Instance.ShowUI(interactType);
        }
    }

    public virtual void OnInteractEnd()
    {
        if (uiObject != null)
        {
            UIManager.Instance.HideUI(interactType);
        }
    }
}