using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for detecting collisions of the snake (WIP)
public class SnakeCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            Debug.Log("Bodycollision :" + other.ToString());
            MovementSnake.instance.CollsionWall();
        }
        else if (other.gameObject.tag == "Level")
        {
            Debug.Log("Levelcollision :" + other.ToString());
        }
        else if (other.gameObject.tag == "Food")
        {
            Debug.Log("Foodcollision :" + other.ToString());
        }
        else
        {
            //Debug.Log("Other collision :" + other.ToString());
        }
    }
   
}
