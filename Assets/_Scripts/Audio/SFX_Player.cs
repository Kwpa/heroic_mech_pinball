using UnityEngine;

public class SFX_Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource source;

    [Header("Settings")]
    [SerializeField][Range(0, 0.5f)] private float pitchVariation = 0f;
    
    public void PlaySound(AudioClip audioClip)
    {
        source.pitch = 1 + Random.Range(-pitchVariation, pitchVariation);
        source.PlayOneShot(audioClip);
    }
}
