using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Plunger : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private InputAction playerControls;

    [Header("Settings")]
    [SerializeField] private float launchForce = 2000;
    [SerializeField] private float cooldownTime = 1;
    private bool cooldown = false;

    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [Header("Event")]
    public UnityEvent plungerFired;

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.performed += LaunchRigidBodies;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.performed -= LaunchRigidBodies;
    }

    private void LaunchRigidBodies(InputAction.CallbackContext context)
    {
        Debug.Log("Input Detected");

        if (cooldown) return; //exit clause 

        foreach (Rigidbody rb in rigidbodies)
        {
            Debug.Log("Adding force to " + rb.gameObject.name);
            rb.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
        }

        StartCoroutine(HandleCooldown());
        plungerFired.Invoke();
    }

    private IEnumerator HandleCooldown()
    {
        cooldown = true;

        yield return new WaitForSeconds(cooldownTime);

        cooldown = false;
    }

    public void AddRbToList(Rigidbody rb)
    {
        rigidbodies.Add(rb);
    }

    public void RemoveRbFromList(Rigidbody rb)
    {
        rigidbodies.Remove(rb);
    }
}
