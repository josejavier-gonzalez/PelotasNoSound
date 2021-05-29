using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerController : MonoBehaviour
{
    
    // properties of rigidbody (the sphere)
    private Rigidbody rb;
    private float movementX, movementY;
    private AudioSource moviendo;
    private AudioSource golpe;
    private AudioSource[] sources;

    
    public float speed = 5.0f;
    private float instspeed = 0;
    private float newpitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sources = GetComponents<AudioSource>();
        moviendo = sources[0];
        golpe = sources[1];
    }

    void FixedUpdate() 
    {
        rb.AddForce(new Vector3(movementX, 0.0f, movementY) * speed);
        instspeed = rb.velocity.magnitude;
        
        if (instspeed > 0)
        {
            newpitch = (float)(1 + 0.5f * (1 - Mathf.Exp(-1*instspeed)));
            //if (newpitch > 1.8f) newpitch = 1.8f;
            //if (newpitch < 0.8f) newpitch = 0.8f;
            moviendo.pitch = newpitch;
            //Debug.Log("velocity " + rb.velocity.magnitude);
            if (!moviendo.isPlaying) moviendo.Play();
        }
        else
        {
            moviendo.pitch = 1;
            //Debug.Log("velocity es cero o menor " + rb.velocity.magnitude);
            if (moviendo.isPlaying) moviendo.Pause();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Golpe Pelota Peaqueña " + collision.rigidbody.tag);
        golpe.Play();
    }
}
