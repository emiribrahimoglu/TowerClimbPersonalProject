using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform leftWallPosition;
    public Transform rightWallPosition;
    public Transform belowBlockerPosition;
    public Transform aboveBlockerPosition;

    private Rigidbody2D rb2d;

    private bool isCameraStartedMoving = false;

    public float cameraSpeed;
    private Vector2 leftWallPositionDistance;
    private Vector2 rightWallPositionDistance;
    private Vector2 belowBlockerPositionDistance;
    private Vector2 aboveBlockerPositionDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        leftWallPositionDistance = transform.position - leftWallPosition.position;
        rightWallPositionDistance = transform.position - rightWallPosition.position;
        belowBlockerPositionDistance = transform.position - belowBlockerPosition.position;
        aboveBlockerPositionDistance = transform.position - aboveBlockerPosition.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        StartCoroutine(StartMovement());
        ObjectsToFollowCamera();
    }

    IEnumerator StartMovement()
    {
        yield return new WaitForSeconds(2);
        if (Input.GetKey(KeyCode.Space) && !isCameraStartedMoving)
        {
            rb2d.velocity = new Vector2(0, cameraSpeed);
            isCameraStartedMoving = true;
        }
    }

    public void ApplyNewCameraSpeed()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.velocity = new Vector2(0, cameraSpeed);
    }

    private void ObjectsToFollowCamera()
    {
        leftWallPosition.position = (Vector2)transform.position + leftWallPositionDistance;
        rightWallPosition.position = (Vector2)transform.position + rightWallPositionDistance;
        belowBlockerPosition.position = (Vector2)transform.position - belowBlockerPositionDistance;
        aboveBlockerPosition.position = (Vector2)transform.position - aboveBlockerPositionDistance;
    }
}
