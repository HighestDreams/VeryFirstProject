using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    private bool equipped = false;

    private float pickupDistance = 5f;

    public Transform player, body;

    public Rigidbody rb;

    public BoxCollider coll;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;


        if(!equipped && distanceToPlayer.magnitude <= pickupDistance && Input.GetKeyDown(KeyCode.E)) {
            equipped = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            transform.SetParent(player);
            transform.localPosition = new Vector3(1.25f, -0.7f, 1.2f);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            transform.localScale = Vector3.one;
        }

        if(equipped && Input.GetKeyDown(KeyCode.Q)) {
            equipped = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            transform.SetParent(null);
            rb.AddForce(player.forward * 22f, ForceMode.Impulse);
            rb.AddForce(player.up * 5f, ForceMode.Impulse);
            float random = Random.Range(-2f, 2f);
            rb.AddTorque(new Vector3(random, random, random) * 10);
        }
    }
}
