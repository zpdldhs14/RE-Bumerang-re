using UnityEngine;

public class ReadObject : InteractableObject
{
    protected override void Awake()
    {
        base.Awake();
        interactType = "read";
    }
} 