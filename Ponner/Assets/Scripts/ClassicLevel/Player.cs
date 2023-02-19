using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string gameMode;

    public float jumpPower;

    public bool checkGround;
    public bool doubleJump;

    public GameObject tracker;

    public GameObject restartPanel;
    public GameObject respawnPlatform;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void JumpController()
    {
        if (checkGround || doubleJump)
        {
            Jump();

            doubleJump = !doubleJump;
        }
    }

    private void Jump()
    {
        if (doubleJump && rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }

        rb.AddForce(transform.up * jumpPower);
        rb.AddForce(transform.forward * jumpPower / 10);
    }

    public void BattleJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }

        rb.AddForce(transform.up * jumpPower);
        rb.AddForce(transform.forward * jumpPower);
    }

    public void Death()
    {
        rb.isKinematic = true;

        if(gameMode == "Classic")
        {
            tracker.GetComponent<Tracker>().enabled = false;
        }

        restartPanel.SetActive(true);
        restartPanel.GetComponent<RestartPanel>().FirstProcess();
    }

    public void Respawn()
    {
        switch (gameMode)
        {
            case "Classic":
                respawnPlatform.SetActive(true);
                respawnPlatform.transform.position = new Vector3(0, tracker.transform.position.y + 12, tracker.transform.position.z + 100);

                rb.isKinematic = false;
                transform.position = new Vector3(0, respawnPlatform.transform.position.y + 3, respawnPlatform.transform.position.z - 15);

                tracker.GetComponent<Tracker>().enabled = true;
                break;

            case "Arena":
                rb.isKinematic = false;
                transform.rotation = Quaternion.identity;
                transform.position = new Vector3(respawnPlatform.transform.position.x, respawnPlatform.transform.position.y + 3, respawnPlatform.transform.position.z - 10);
                break;
        }
    }
}
