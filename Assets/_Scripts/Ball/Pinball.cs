using UnityEngine;
using UnityEngine.UIElements;

public class Pinball : MonoBehaviour
{
    private Vector3 plungerPos;

    private void Start()
    {
        plungerPos = transform.position;
    }

    public void ResetBallPos()
    {
        transform.position = plungerPos;
    }
}
