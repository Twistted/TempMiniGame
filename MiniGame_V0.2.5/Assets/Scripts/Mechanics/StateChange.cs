using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;

namespace MiniGame.Mechanics
{
    public class StateChange : MonoBehaviour
    {
        public bool state;//世界的状态
        public GameObject player;//游戏玩家
        private GameObject[] TrueWalls;//创建一个全部true墙的GameObject类型的数组
        private GameObject[] FalseWalls;//创建一个全部false墙的GameObject类型的数组
        private Color32 tr_red = new Color32(255, 0, 0, 50);
        private Color32 tr_green = new Color32(0, 255, 0, 50);

        // Start is called before the first frame update
        void Start()
        {
            TrueWalls = GameObject.FindGameObjectsWithTag("TrueWall");//查找标签
            FalseWalls = GameObject.FindGameObjectsWithTag("FalseWall");//查找标签

            if (state == true)
            {
                for (int i = 0; i < TrueWalls.Length; i++)
                {
                    TrueWalls[i].GetComponent<BoxCollider>().enabled = false;
                    TrueWalls[i].GetComponent<MeshRenderer>().material.color = tr_red;
                }
                for (int i = 0; i < FalseWalls.Length; i++)
                {
                    FalseWalls[i].GetComponent<BoxCollider>().enabled = true;
                    FalseWalls[i].GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
            else if (state == false)
            {
                for (int i = 0; i < TrueWalls.Length; i++)
                {
                    TrueWalls[i].GetComponent<BoxCollider>().enabled = true;
                    TrueWalls[i].GetComponent<MeshRenderer>().material.color = Color.red;
                }
                for (int i = 0; i < FalseWalls.Length; i++)
                {
                    FalseWalls[i].GetComponent<BoxCollider>().enabled = false;
                    FalseWalls[i].GetComponent<MeshRenderer>().material.color = tr_green;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("change state !");
                if (state)
                    state = false;
                else state = true;
            }

            if (state == false)
            {
                player.GetComponent<MeshRenderer>().material.color = Color.green;

                for (int i = 0; i < TrueWalls.Length; i++)
                {
                    TrueWalls[i].GetComponent<BoxCollider>().enabled = true;
                    TrueWalls[i].GetComponent<MeshRenderer>().material.color = Color.red;
                }
                for (int i = 0; i < FalseWalls.Length; i++)
                {
                    FalseWalls[i].GetComponent<BoxCollider>().enabled = false;
                    FalseWalls[i].GetComponent<MeshRenderer>().material.color = tr_green;
                }
            }
            else
            {
                player.GetComponent<MeshRenderer>().material.color = Color.red;

                for (int i = 0; i < TrueWalls.Length; i++)
                {
                    TrueWalls[i].GetComponent<BoxCollider>().enabled = false;
                    TrueWalls[i].GetComponent<MeshRenderer>().material.color = tr_red;
                }
                for (int i = 0; i < FalseWalls.Length; i++)
                {
                    FalseWalls[i].GetComponent<BoxCollider>().enabled = true;
                    FalseWalls[i].GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
        }
    }
}
