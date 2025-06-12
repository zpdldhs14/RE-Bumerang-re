using UnityEngine;

public class CDObject : InteractableObject
{
    protected override void Awake()
    {
        base.Awake();
        interactType = "CD";
    }
} 