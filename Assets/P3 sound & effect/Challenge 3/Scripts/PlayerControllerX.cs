using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    // Batas atas dan bawah
    private float upperLimit = 14.5f;
    private float lowerLimit = 2f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        // Modifikasi gravitasi 
        Physics.gravity *= gravityModifier;

        // Tambahan gaya awal
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        // BATAS ATAS 
        if (transform.position.y > upperLimit)
        {
            transform.position = new Vector3(transform.position.x, upperLimit, transform.position.z);
            playerRb.velocity = Vector3.zero; // hentikan gerakan ke atas
        }

        // BATAS BAWAH
        if (transform.position.y < lowerLimit)
        {
            transform.position = new Vector3(transform.position.x, lowerLimit, transform.position.z);
            playerRb.velocity = Vector3.zero; // hentikan gerakan ke bawah
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // game over bomb
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        // effect uang
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}