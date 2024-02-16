using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    bool isOnGround;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            playerAnimator.SetTrigger("Jump_trig");
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, .5f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && !gameOver) {
            dirtParticle.Play();
            isOnGround = true;
        } else if (other.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, .7f);
            Debug.Log("Game Over");
        }
    }
}
