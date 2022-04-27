using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour
{
    private Player thePlayer = new Player("Mike");
    private Rigidbody rb;
    public float speed = 20f;
    private int count = 0;
    public GameObject player;
    private int destroyCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        CORE.setPlayer(thePlayer);
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public Player getPlayer()
    {
        return this.thePlayer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {

            Destroy(CORE.destroyRoom());
            CORE.setDestroyCount(destroyCount);
            destroyCount++;
            count++;
            if (count == 14)
            {
                this.thePlayer.addKill();
                print("Kill Count: " + this.thePlayer.getKillCount());
            }
        }
        if (collision.gameObject.tag.Equals("player"))
        {
            //Destroy(this.gameObject.tag.Equals("enemy"));
            count++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("I would have been des");
            Destroy(player);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //print(thePlayer.getName());
        if (Input.GetKeyDown("up"))
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (Input.GetKeyDown("down"))
        {
            rb.velocity = Vector3.back * speed;
        }
        else if (Input.GetKeyDown("left"))
        {
            rb.velocity = Vector3.left * speed;
        }
        else if (Input.GetKeyDown("right"))
        {
            rb.velocity = Vector3.right * speed;
        }
        else if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector3.up * speed;
        }
        else if(Input.GetKeyDown("f"))
        {
            print("fire");
        }
    }
}
