using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;

namespace MiniGame.Mechanics
{
    public class Grounded : MonoBehaviour
    {
        private GameObject player;

        void Start()
        {
            player = GameObject.Find("/Player/Player_Cube");
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<BoxCollider>().enabled == true && collider.GetComponent<BoxCollider>().isTrigger == false)
            {
                player.GetComponent<PlayerController>().IsGrounded = true;
            }
        }
        void OnTriggerStay(Collider collider)
        {
            if (collider.GetComponent<BoxCollider>().enabled == true && collider.GetComponent<BoxCollider>().isTrigger == false)
            {
                player.GetComponent<PlayerController>().IsGrounded = true;
            }
        }
        void OnTriggerExit(Collider collider)
        {
            if (collider.GetComponent<BoxCollider>().enabled == true && collider.GetComponent<BoxCollider>().isTrigger == false)
            {
                player.GetComponent<PlayerController>().IsGrounded = false;
            }
        }
    }
}
