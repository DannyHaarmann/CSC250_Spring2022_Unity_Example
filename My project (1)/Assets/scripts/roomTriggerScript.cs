using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTriggerScript : MonoBehaviour
{
    private Room thisRoom;
    

    // Start is called before the first frame update
    void Awake()
    {
       // print("*************** Room trigger is awake *************");
    }

    void Start()
    {
        //print("*************** Room trigger has started *************");
        this.thisRoom = new Room();
        CORE.addRoom(this.thisRoom);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            this.thisRoom.setPlayer(CORE.getPlayer());
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            this.thisRoom.setEnemy(CORE.getEnemy());
           // print("Enemy Entered room " + this.gameObject.ToString());
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(CORE.destroyRoom());
        }
        else if(other.gameObject.tag.Equals("enemy"))
        {
            Destroy(CORE.destroyRoom());
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
