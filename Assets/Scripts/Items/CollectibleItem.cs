using UnityEngine;

/// <summary>
/// 획득 가능한 아이템 클래스입니다.
/// </summary>
public class CollectibleItem : InteractableObject
{
    [SerializeField] private int itemId;
    [SerializeField] private string itemName;
    [SerializeField] private int scoreValue = 100;

    /// <summary>
    /// 아이템과 상호작용할 때 호출됩니다.
    /// </summary>
    // public override void Interact()
    // {
    //     if (!isInteractable) return;
    //
    //     // 아이템 획득 이벤트 발생
    //     EventManager.Instance.TriggerEvent("ItemCollected", itemId);
    //     
    //     // 아이템 비활성화
    //     SetInteractable(false);
    //     gameObject.SetActive(false);
    //     
    //     Debug.Log($"{itemName}을(를) 획득했습니다!");
    // }
} 