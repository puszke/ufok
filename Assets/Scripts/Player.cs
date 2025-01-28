using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject zoi, ind;

    private Rigidbody rb;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump(float force)
    {
        rb.velocity = new Vector3(rb.velocity.x,0,0);
        rb.AddTorque(new Vector3(force,force,force),ForceMode.Impulse);
        rb.AddForce(new Vector3(0, force, 0),ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        zoi.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        zoi.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        ind.SetActive(transform.position.y > 17);
        ind.transform.position = new Vector3(transform.position.x,ind.transform.position.y,ind.transform.position.z);

        zoi.transform.position = transform.position;

        float x = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector3(x*speed, 0, 0),ForceMode.Acceleration);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump(40);
    }
}
