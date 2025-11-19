using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform ball;

    [Header("Settings")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float minZPos;
    [SerializeField] private float maxZPos;
    private float xPos;
    private float yPos;
    private float zPos;
    private float zOffset;
    Vector3 velocity = Vector3.zero;


    private void Start()
    {
        //set initial position
        xPos = transform.position.x;
        yPos = transform.position.y;

        zOffset = transform.position.z - ball.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float ballPos = ball.position.z + zOffset;

        //determine z position
        if (ballPos > maxZPos)
        {
            zPos = maxZPos;
        }
        else if (ballPos < minZPos)
        {
            zPos = minZPos;
        }
        else
        {
            zPos = ballPos;
        }

        //move towards target position
        Vector3 targetPos = new Vector3(xPos, yPos, zPos);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, (1/speed));
    }
}
