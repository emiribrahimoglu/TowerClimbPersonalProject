using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_PlatformPlayerDestroyer : MonoBehaviour
{
    private bool isPlayerDead = false;
    public GameObject playerCharacter;
    public GameObject _Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) && isPlayerDead)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(collision.gameObject, 2f);
        }
        if (collision.gameObject.CompareTag("Player")) //Biri kinematic rigidbody, diğeri dinamik, dolayısıyla çalışmıyor
        {
            isPlayerDead = true;
            playerCharacter.GetComponent<script_PlayerChar>().enabled = false;
            Destroy(collision.gameObject, 2f);
            _Camera.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
