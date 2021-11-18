using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bal : MonoBehaviour
{
    public int teamGreenScore = 0;

    public int teamPurpleScore = 0;

    Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.tag == "green")
        {
            teamPurpleScore += 1;
        }


        if(other.tag == "purple")
        {
            teamGreenScore += 1;
        }
        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
