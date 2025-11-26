using UnityEngine;
using UnityEngine.Events;

public class Spinners : MonoBehaviour
{
    public UnityEvent SpinnerHit;


    private void OnCollisionEnter(Collision collision)
    {
        SpinnerHit.Invoke();
    }
}
