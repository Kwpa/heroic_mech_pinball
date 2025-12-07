using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Spinners : MonoBehaviour
{
    public UnityEvent SpinnerHit;

    [SerializeField] private List<AudioClip> spinningSFX = new List<AudioClip>();
    [SerializeField] private SFX_Player sfxPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        sfxPlayer.PlaySound(spinningSFX[Random.Range(0, spinningSFX.Count)]);
        SpinnerHit.Invoke();
    }
}
