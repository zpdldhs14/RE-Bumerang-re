using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInteraction : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private IInteractable currentInteractable;
    private PlayerState currentState = PlayerState.Idle;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HandleEscapeKey();
        UpdatePlayerState();
        HandleInteraction();
    }

    private void HandleEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.HideAllUI();
            SetState(PlayerState.Idle);
        }
    }

    private void UpdatePlayerState()
    {
        if (UIManager.Instance.IsAnyUIActive())
        {
            SetState(PlayerState.Interacting);
        }
        else if (currentState != PlayerState.Moving)
        {
            SetState(PlayerState.Idle);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero
            );

            if (hit.collider != null)
            {
                MonoBehaviour[] components = hit.collider.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour component in components)
                {
                    if (component is IInteractable interactable)
                    {
                        currentInteractable = interactable;
                        SetState(PlayerState.Moving);
                        break;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentInteractable != null)
        {
            MonoBehaviour interactableComponent = currentInteractable as MonoBehaviour;
            if (interactableComponent != null && other.gameObject == interactableComponent.gameObject)
            {
                currentInteractable.Interact();
                SetState(PlayerState.Interacting);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentInteractable != null)
        {
            MonoBehaviour interactableComponent = currentInteractable as MonoBehaviour;
            if (interactableComponent != null && other.gameObject == interactableComponent.gameObject)
            {
                currentInteractable.OnInteractEnd();
                SetState(PlayerState.Idle);
            }
        }
    }

    private void SetState(PlayerState newState)
    {
        if (currentState == newState) return;
    
        currentState = newState;
        switch (currentState)
        {
            case PlayerState.Idle:
                playerMovement.SetCanMove(true);
                break;
            case PlayerState.Moving:
                playerMovement.SetCanMove(true);
                break;
            case PlayerState.Interacting:
                playerMovement.SetCanMove(false);
                break;
        }
    }
}