using UnityEngine;
using UnityEngine.Events;

public class Bumper : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float bounceForce = 50;

    [Header("Event")]
    public UnityEvent bumperHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //get info
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 contactPoint = collision.GetContact(0).point;

            //determine force direction
            Vector3 normal = (contactPoint - transform.position).normalized;
            //Vector3 forceDir = Vector3.Reflect(ballRB.linearVelocity, normal);

            ballRB.AddForce(normal * bounceForce, ForceMode.Impulse);

            bumperHit.Invoke();
        }
    }
}
