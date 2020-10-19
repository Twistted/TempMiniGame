using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniGame.Mechanics;
using MiniGame.Gameplay;

namespace MiniGame.UI
{
    public class GetObject : MonoBehaviour
    {
        private GameObject player;
        public GameObject story;

        void Start()
        {
            player = GameObject.Find("/Player/Player_Cube");
        }

        public void get()
        {
            story.SetActive(false);
            player.GetComponent<PlayerController>().controlEnabled = true;//玩家可控
            player.GetComponent<Rigidbody>().isKinematic = false;//添加动力系统
        }
    }
}
