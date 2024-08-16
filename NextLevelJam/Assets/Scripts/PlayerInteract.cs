using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public PlayerWork playerWork;
    public BoxCollider coll;
    public Animator spriteAnim;

    private bool canInteract;

    private Interactable interactable;

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        if (canInteract)
        {
            if (interactable != null)
            {
                interactable.Interact(playerWork);

                spriteAnim.SetTrigger("Work");
            }
        }
    }

    public void SecondInteraction(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        if (canInteract)
        {
            if (interactable != null)
            {
                interactable.SecondaryInteraction();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            canInteract = true;

            if (interactable != null)
            {
                interactable.ShowRequired(false);
            }

            interactable = other.GetComponentInChildren<Interactable>();
            interactable.ShowRequired(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            canInteract = false;

            if (interactable != null)
            {
                interactable.ShowRequired(false);
            }

            interactable = null;
        }
    }
}
