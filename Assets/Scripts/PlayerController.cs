using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody   playerRB;
    private Animator    playerAnimator;
    private AudioSource playerAudio;

    // Prefabs
    [SerializeField]
    private ParticleSystem  explosionParticle;
    [SerializeField]
    private ParticleSystem  dirtParticle;
    [SerializeField]
    private AudioClip       jumpSound;
    [SerializeField]
    private AudioClip       crashSound;

    // Game over instance
    [SerializeField]
    private GameOverController gameOverScreen;

    // Movement values
    [SerializeField]
    private float           jumpForce       = 10.0f;
    [SerializeField]
    private float           gravityModifier = 1f;

    private bool            isOnGround;
    public  bool            gameOver {  get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerRB        = GetComponent<Rigidbody>();
        playerAnimator  = GetComponent<Animator>();
        playerAudio     = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        gameOver        = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground") && !gameOver) {
            Land();
        } else if (other.gameObject.CompareTag("Obstacle")) {
            CollideWithObstacle();
        }
    }

    private void Jump() {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;

        dirtParticle.Stop();
        playerAnimator.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, .5f);
    }

    private void Land() {
        dirtParticle.Play();
        isOnGround = true;
    }

    private void CollideWithObstacle() {
        gameOver = true;
        if(gameOverScreen != null) {
            gameOverScreen.Show();
        }

        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", 1);
        dirtParticle.Stop();

        explosionParticle.Play();
        playerAudio.PlayOneShot(crashSound, .7f);
    }
}
