using UnityEngine;

public class MessageTester : MonoBehaviour
{
    [SerializeField] private string message;

    public void LogMessage()
    {
        Debug.Log(message);
    }
}
