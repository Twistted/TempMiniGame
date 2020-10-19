using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;
using System.Collections.Specialized;

namespace MiniGame.Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        public float maxSpeed;//最大速度
        public float jumpTakeOffSpeed;//起跳速度
        public float playerExtraGravity;//玩家修正重力
        private Vector3 playerExtraGravityVector = Vector3.zero;//玩家修正重力向量
        private Rigidbody playerRig;//玩家刚体

        public JumpState jumpState = JumpState.Grounded;//跳跃状态
        public bool controlEnabled;//是否可控
        public bool IsGrounded;//是否在地上
        Vector3 move;//移动方向

        public int EmoNumber;//收集情感元件的个数
        public int DatNumber;//收集数据元件的个数

        //internal Animator animator;//动画
        //public AudioClip Audio;//音效
        //readonly MiniGameModel model = Simulation.GetModel<MiniGameModel>();//获取模型

        void Start()
        {
            playerRig = this.GetComponent<Rigidbody>();
            EmoNumber = 0;
            DatNumber = 0;
        }

        void Update()
        {
            playerExtraGravityVector[1] = -playerExtraGravity;
            playerRig.AddForce(playerExtraGravityVector, ForceMode.Acceleration);

            if (Input.GetAxis("Horizontal") != 0 && controlEnabled)
            {
                this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") / (200f / maxSpeed), 0, 0));
            }

            if (controlEnabled)
            {
                if (IsGrounded && jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                {
                    Debug.Log("PrepareToJump !");
                    jumpState = JumpState.PrepareToJump;
                }
            }
            UpdateJumpState();
        }

        void UpdateJumpState()
        {
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    Debug.Log("InFlight !");
                    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpTakeOffSpeed * 100f);
                    jumpState = JumpState.InFlight;
                    break;
            }
            if(IsGrounded)
                //Debug.Log("Grounded !");
            jumpState = JumpState.Grounded;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            InFlight
        }
    }
}
