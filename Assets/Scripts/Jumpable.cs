using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour
{
    public Component ai;
    public GameObject booms;
    public float JumpForce=45;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().Jump(JumpForce);
            GetComponent<Rigidbody>().AddTorque(new Vector3(10,10,10),ForceMode.Impulse);
            GetComponent<BoxCollider>().enabled = false;
            Destroy(ai);
            GameObject newBooms = Instantiate(booms, transform.position, Quaternion.identity);
            Destroy(newBooms,2);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
