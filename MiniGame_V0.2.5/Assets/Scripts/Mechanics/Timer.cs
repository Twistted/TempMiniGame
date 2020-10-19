using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;

namespace MiniGame.Mechanics
{
    public class Timer : MonoBehaviour
    {
        public bool work;//是否工作
        private bool timer;//是否开始计时
        private float lastTime;//开始时间
        private float curTime;//当前时间

        void Start()
        {
            work = false;
            timer = false;
            lastTime = 0;
            curTime = 0;
        }

        void Update()
        {
            if (work == true && timer == false)
            {
                this.GetComponent<MeshRenderer>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;

                timer = true;
                lastTime = Time.time;
            }
            if (work == true && timer == true)
            {
                curTime = Time.time;
                if (curTime - lastTime >= 4)
                {
                    this.GetComponent<MeshRenderer>().enabled = true;
                    this.GetComponent<BoxCollider>().enabled = true;

                    work = false;
                    timer = false;
                    lastTime = 0;
                    curTime = 0;
                }
            }
        }
    }
}
