using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueController : MonoBehaviour
{
    private float bloquesize;
    private float newpitch;
    private AudioSource golpe;
    // Start is called before the first frame update
    void Start()
    {
     
        golpe = GetComponent<AudioSource>();

        bloquesize = transform.localScale.x * transform.localScale.y * transform.localScale.z;
        newpitch = (float)(1 + 0.5f * (1 - Mathf.Exp(-1 * bloquesize)));
        golpe.pitch = newpitch;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Tamaño " + transform.localScale.x.ToString());
     
        

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pitch Size " + newpitch.ToString());
        Debug.Log("Golpe Bloque " + collision.rigidbody.tag);
        golpe.Play();
    }
}
