using UnityEngine;

public class MessageObject : InteractableObject
{
    protected override void Awake()
    {
        base.Awake();
        interactType = "messeage";
    }
} 