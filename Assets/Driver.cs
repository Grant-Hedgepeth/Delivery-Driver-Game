using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    public AudioClip Gascan;
    public AudioClip Backgroundsong;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        audioSource2.clip = Backgroundsong;
        audioSource2.loop = true;
        audioSource2.Play();
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    moveSpeed = slowSpeed; 
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boost")
        {
            audioSource1.clip = Gascan;
            audioSource1.Play();
        }
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
       
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
