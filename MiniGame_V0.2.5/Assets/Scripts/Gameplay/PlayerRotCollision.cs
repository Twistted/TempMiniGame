using MiniGame.Mechanics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace MiniGame.Gameplay
{
    public class PlayerRotCollision : MonoBehaviour
    {
        public GameObject[] part;
        public bool dir;//记录旋转方向，true为顺时针，false为逆时针
        private float lerp_time;//记录旋转时间
        private bool rotating;//记录是否正在旋转
        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            lerp_time = 0f;
            rotating = false;
            player = GameObject.Find("/Player/Player_Cube");
        }

        void Update()
        {
            if (rotating)
            {
                if (lerp_time < 90f)
                {
                    Rotate_Func();
                }
                if (lerp_time == 90f)
                {
                    lerp_time = 0f;
                    rotating = false;
                    if (dir)
                        dir = false;
                    else dir = true;
                    player.GetComponent<PlayerController>().controlEnabled = true;//玩家可控
                    player.GetComponent<Rigidbody>().isKinematic = false;//回复动力系统
                }
            }
        }

        void Rotate_Func()
        {
            if (dir)
            {
                part[0].transform.Rotate(Vector3.forward * -1f);
                part[3].transform.Rotate(Vector3.forward * -1f);
                part[4].transform.Rotate(Vector3.forward * -1f);
                part[7].transform.Rotate(Vector3.forward * -1f);
                part[8].transform.Rotate(Vector3.forward * -1f);
                part[9].transform.Rotate(Vector3.forward * 1f);
            }
            else
            {
                part[0].transform.Rotate(Vector3.forward * 1f);
                part[3].transform.Rotate(Vector3.forward * 1f);
                part[4].transform.Rotate(Vector3.forward * 1f);
                part[7].transform.Rotate(Vector3.forward * 1f);
                part[8].transform.Rotate(Vector3.forward * 1f);
                part[9].transform.Rotate(Vector3.forward * -1f);
            }
            lerp_time += 1f;
        }

        void OnTriggerStay(Collider collider)//这个函数在碰撞开始时候调用
        {
            if (collider.gameObject == player && Input.GetButtonDown("Enter Rotate") && player.GetComponent<PlayerController>().IsGrounded == true)
            {

                Debug.Log("Rotate !");
                rotating = true;//开始旋转
                player.GetComponent<PlayerController>().controlEnabled = false;//玩家不可控
                player.GetComponent<Rigidbody>().isKinematic = true;//去除动力系统

                this.GetComponent<Timer>().work = true;
            }
        }
    }
}


