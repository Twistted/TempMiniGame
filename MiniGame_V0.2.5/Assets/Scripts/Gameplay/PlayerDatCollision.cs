using MiniGame.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.UI;

namespace MiniGame.Gameplay
{
    public class PlayerDatCollision : MonoBehaviour
    {
        public GameObject player;
        public GameObject story;
        public GameObject Character;
        public GameObject Room;
        private GameObject MagicCube;
        private bool exit;

        void Start()
        {
            MagicCube = GameObject.Find("/Magic_Cube");
            exit = false;
        }

        void OnTriggerEnter(Collider collider)//这个函数在碰撞开始时候调用
        {
            if (MagicCube.GetComponent<StateChange>().state == true && exit == false)
            {
                exit = true;
                player.GetComponent<PlayerController>().DatNumber += 1;
                Character.GetComponent<CharacterProgress>().add = true;
                Room.GetComponent<RoomProgress>().add = true;

                story.SetActive(true);
                player.GetComponent<PlayerController>().controlEnabled = false;//玩家不可控
                player.GetComponent<Rigidbody>().isKinematic = true;//去除动力系统

                Destroy(this.gameObject);
            }
        }
    }
}
