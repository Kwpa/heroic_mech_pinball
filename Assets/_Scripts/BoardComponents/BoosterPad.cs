using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour
{
    [SerializeField] private float force;
    private List<Rigidbody> ballRBs = new List<Rigidbody>();
    private Vector3 forceDir;

    private void Start()
    {
        forceDir = transform.up;
        Debug.Log(gameObject.name + ": " + forceDir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballRBs.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballRBs.Remove(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (Rigidbody rb in ballRBs)
        {
            Debug.Log("AddingForce");
            rb.AddForce(forceDir * force, ForceMode.Force);
        }
    }
}
