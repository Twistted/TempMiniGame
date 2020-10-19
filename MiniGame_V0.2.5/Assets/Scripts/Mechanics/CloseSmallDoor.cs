using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;
using MiniGame.UI;

namespace MiniGame.Mechanics
{
    public class CloseSmallDoor : MonoBehaviour
    {
        public GameObject SmallDoor_a;
        public GameObject SmallDoor_b;
        public GameObject Room;

        void OnTriggerExit(Collider collider)//这个函数在碰撞结束时候调用
        {
            SmallDoor_a.GetComponent<BoxCollider>().enabled = true;
            SmallDoor_a.GetComponent<MeshRenderer>().material.color = Color.white;
            SmallDoor_b.GetComponent<BoxCollider>().enabled = true;
            SmallDoor_b.GetComponent<MeshRenderer>().material.color = Color.white;
            Room.GetComponent<RoomProgress>().reset = true;
            print("close !");
        }
    }
}
