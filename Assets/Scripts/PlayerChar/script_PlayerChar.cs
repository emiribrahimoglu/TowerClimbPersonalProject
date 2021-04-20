using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_PlayerChar : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private int amountOfPlatformsLandedOn;
    public int landingNeededToIncreaseCameraSpeed;
    public float incrementOfCameraSpeed;

    public GameObject _camera;
    private CameraController cameraScript;

    private Rigidbody2D rb2d;

    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cameraScript = _camera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementHandler();
        JumpingHandler();
    }

    private void MovementHandler()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.position += movement * speed * Time.fixedDeltaTime;
    }

    private void JumpingHandler()
    {
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, jumpPower));
            canJump = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(new Vector2(0, -50));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
            amountOfPlatformsLandedOn++;
            if (amountOfPlatformsLandedOn == landingNeededToIncreaseCameraSpeed)
            {
                cameraScript.cameraSpeed += incrementOfCameraSpeed;
                cameraScript.ApplyNewCameraSpeed();
                amountOfPlatformsLandedOn = 0;
            }
        }
    }
}
