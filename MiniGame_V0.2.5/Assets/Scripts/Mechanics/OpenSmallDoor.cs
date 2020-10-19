using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;
using System;

namespace MiniGame.Mechanics
{
    public class OpenSmallDoor : MonoBehaviour
    {
        public int EmoNum;//需要收集情感元件的个数
        public int DatNum;//需要收集数据元件的个数
        private GameObject player;
        private Color32 orange = new Color32(255, 146, 0, 255);
        private bool open;//判断是否打开过
        void Start()
        {
            player = GameObject.Find("/Player/Player_Cube");
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<MeshRenderer>().material.color = Color.white;
            open = false;
        }

        void Update()
        {
            if (player.GetComponent<PlayerController>().EmoNumber == EmoNum && player.GetComponent<PlayerController>().DatNumber == DatNum && !open)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<MeshRenderer>().material.color = orange;
                open = true;
            }
        }
    }
}
