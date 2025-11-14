using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    [SerializeField] private UnityEvent pinballSunk;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            pinballSunk.Invoke();
            Debug.Log("Event Invoked");
        }
    }
}
