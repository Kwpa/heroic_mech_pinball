using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    [SerializeField] private UnityEvent pinballSunk;
    [SerializeField] private SFX_Player sfxPlayer;
    [SerializeField] private AudioClip holeSFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            pinballSunk.Invoke();
            sfxPlayer.PlaySound(holeSFX);
        }
    }
}
