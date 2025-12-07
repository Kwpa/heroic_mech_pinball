using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float launchForce = 45;
    [SerializeField] private float grabTime = 0.3f;

    [Header("Visuals")]
    [SerializeField] private GameObject offVisual;
    [SerializeField] private GameObject onVisual;

    [Header("Automation")]
    [SerializeField] private bool useTimer = false;
    [SerializeField] private float holdTime = 1;

    [Header("Events")]
    public UnityEvent ActivatorHit;

    [Header("SFX")]
    [SerializeField] private AudioClip activatorSFX;
    [SerializeField] private SFX_Player sfxPlayer;

    private Collider collider;
    private Rigidbody ballRB;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        DisableTrigger();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && ballRB == null)
        {
            ActivatorHit.Invoke();
            StartCoroutine(GrabBall(other.GetComponent<Rigidbody>()));
        }
    }

    public void ActivateTrigger()
    {
        collider.enabled = true;
        offVisual.SetActive(false);
        onVisual.SetActive(true);
    }

    public void DisableTrigger()
    {
        collider.enabled = false;
        offVisual.SetActive(true);
        onVisual.SetActive(false);
    }

    private IEnumerator GrabBall(Rigidbody ball)
    {
        Debug.Log("Grabbing Ball");

        //disable ball physics and cache ball
        ballRB = ball;
        DisableBallRB(ball);

        //determine values for position lerp
        Vector3 originalBallPos = ball.transform.position;
        Vector3 holdPos = new Vector3(transform.position.x, originalBallPos.y, transform.position.z);

        //lerp into position
        float timer = 0;
        while (timer < grabTime)
        {
            ball.transform.position = Vector3.Lerp(originalBallPos, holdPos, timer / grabTime);
            timer += Time.deltaTime;
            yield return null;
        }
        ball.transform.position = holdPos;

        if (useTimer)
        {
            StartCoroutine(HoldBallTimer());
        }
    }

    private void DisableBallRB(Rigidbody ball)
    {
        //disable collisions, gravity, and speed
        ball.linearVelocity = Vector3.zero;
        ball.useGravity = false;
        ball.isKinematic = true;
    }

    private void EnableBallRB(Rigidbody ball)
    {
        //enable collisions, gravity, and speed
        ball.useGravity = true;
        ball.isKinematic = false;
    }

    public void LaunchBall()
    {
        //re-enable ball
        EnableBallRB(ballRB);

        //generate direction
        Vector3 forceDir = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)).normalized;
        Debug.Log("Direction: X" + forceDir.x.ToString("0.00") + " Z" + forceDir.z.ToString("0.00"));
        ballRB.AddForce(forceDir * launchForce, ForceMode.Impulse);

        sfxPlayer.PlaySound(activatorSFX);

        //reset state
        ballRB = null;
        DisableTrigger();
    }

    public IEnumerator HoldBallTimer()
    {
        Debug.Log("Holding Ball");

        yield return new WaitForSeconds(holdTime);

        LaunchBall();
    }
}
