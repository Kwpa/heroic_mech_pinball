using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Bumper : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float bounceForce = 50;

    [Header("Event")]
    public UnityEvent bumperHit;

    [Header("Tween Settings")]
    [SerializeField] private float punchScale = 1.15f;
    [SerializeField] private float punchduration = 0.3f;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private float elasticity = 0.5f;

    [Header("SFX")]
    [SerializeField] private List<AudioClip> bumpSFX;
    [SerializeField] private List<AudioClip> dingSFX;
    [SerializeField] private List<AudioClip> zapSFX;

    [Header("Reference")]
    [SerializeField] private SFX_Player sfxPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //get info
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 contactPoint = collision.GetContact(0).point;

            //determine force direction
            Vector3 normal = (contactPoint - transform.position).normalized;
            //Vector3 forceDir = Vector3.Reflect(ballRB.linearVelocity, normal).normalized;

            ballRB.AddForce(normal * bounceForce, ForceMode.Impulse);

            //feedback on hit
            transform.DOPunchScale(Vector3.one * punchScale, punchduration, vibrato, elasticity);
            PlaySFX();

            bumperHit.Invoke();
        }
    }

    private void PlaySFX()
    {
        AudioClip bump = bumpSFX[Random.Range(0, bumpSFX.Count)];
        AudioClip ding = dingSFX[Random.Range(0, dingSFX.Count)];
        AudioClip zap = zapSFX[Random.Range(0, zapSFX.Count)];

        Debug.Log(zap.name);
        sfxPlayer.PlaySound(bump);
        sfxPlayer.PlaySound(ding);
        sfxPlayer.PlaySound(zap);
    }
}
