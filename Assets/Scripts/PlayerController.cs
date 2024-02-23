using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticles; 
    public ParticleSystem dirtParticles;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private float jumpForce = 600;
    private float gravityModifier = 1.5f;
    private bool isGrounded = true;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded&&!gameOver)
        {
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAudio.PlayOneShot(jumpSound);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticles.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
            explosionParticles.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
    }

}
