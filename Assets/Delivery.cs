using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;
    public Sprite yesPackage;
    public Sprite noPackage;

    public AudioClip PickupBox;
    public AudioClip Thankyou;
    public AudioClip Crash;
    public AudioSource audioSource1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource1.clip = Crash;
        audioSource1.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.sprite = yesPackage;
            audioSource1.clip = PickupBox;
            audioSource1.Play();
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = true;
            spriteRenderer.sprite = noPackage;
            audioSource1.clip = Thankyou;
            audioSource1.Play();
        }
    }
}
