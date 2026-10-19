using UnityEngine;
using System.Collections;

public class BallReset : MonoBehaviour
{
    public float minimumHeight = -1f;
    public float resetDelay = 2f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody ballRigidbody;
    private bool isResetting = false;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < minimumHeight && !isResetting)
        {
            StartCoroutine(ResetBall());
        }
    }

    private IEnumerator ResetBall()
    {
        isResetting = true;

        yield return new WaitForSeconds(resetDelay);

        ballRigidbody.linearVelocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        isResetting = false;
    }
}