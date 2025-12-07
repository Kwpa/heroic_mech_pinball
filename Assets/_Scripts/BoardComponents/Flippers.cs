using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flippers : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private InputAction playerControls;

    [Header("References")]
    [SerializeField] private HingeJoint joint;
    [SerializeField] private SFX_Player sfxPlayer;

    [Header("Settings")]
    [SerializeField] private float springForce = 5000;
    [SerializeField] private float springDampening = 300f;
    [SerializeField] private float activatedPos = 40;
    [SerializeField] private float inactivePos = 0;
    private float inactivePosition;

    [Header("SFX")]
    [SerializeField] private List<AudioClip> bumperSFX = new List<AudioClip>();

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.performed += ToggleFlipper;
        playerControls.canceled += ToggleFlipper;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.performed -= ToggleFlipper;
        playerControls.canceled -= ToggleFlipper;
    }

    private void Awake()
    {
        SetSpring(inactivePos);
    }

    private void ToggleFlipper(InputAction.CallbackContext context)
    {

        if (context.canceled)
        {
            SetSpring(inactivePos);
        }
        else
        {
            PlaySFX();
            SetSpring(activatedPos);
        }
    }

    private void SetSpring(float targetPos)
    {
        JointSpring spring = new JointSpring();
        spring.spring = springForce;
        spring.damper = springDampening;
        spring.targetPosition = targetPos;

        joint.spring = spring;

        JointLimits jointLimits = new JointLimits();
        jointLimits.min = targetPos;

        joint.limits = jointLimits;
    }

    private void PlaySFX()
    {
        AudioClip sfx = bumperSFX[Random.Range(0, bumperSFX.Count)];
        sfxPlayer.PlaySound(sfx);
    }
}
