using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private AudioSource moviendo;
    private AudioSource golpe;
    private AudioSource[] sources;
    public float speed = 0;
    private float instspeed = 0;
    private float newpitch = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sources = GetComponents<AudioSource>();
        moviendo = sources[0];
        golpe = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        instspeed = rb.velocity.magnitude;
        
        if (instspeed > 0)
        {
            newpitch = (float)(1 + 0.5f * (1 - Mathf.Exp(-1 * instspeed)));
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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Golpe Pelota Grande " + collision.rigidbody.tag);
        golpe.Play();
    }
}
