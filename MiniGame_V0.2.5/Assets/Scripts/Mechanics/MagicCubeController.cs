using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace MiniGame.Mechanics
{
    public class MagicCubeController : MonoBehaviour
    {
        public GameObject[] part;
        public string[] rotationKey;//旋转的按钮
        public float rotTime;//转动一次花费的时间

        public AnimationCurve curve;//x轴是移动时间，y轴是移动量
        private int rotationDir;//旋转的类型
        public float lerp_time;//记录旋转时间
        private GameObject player;
        private bool isRot;//判断在旋转中
        private bool add;//判断旋转过程中是否增加角度
        public Vector3 nowRot;//现在的旋转位姿
        public Vector3 rot;//旋转角度
        public Vector3 tagRot;//目标旋转位姿

        void Start()
        {
            lerp_time = 0f;
            player = GameObject.Find("/Player/Player_Cube");
            rotationDir = 0;
            add = false;
        }

        void Update()
        {
            if (lerp_time == 0f)
            {
                for (int i = 0; i < rotationKey.Length; i++)
                {
                    if (Input.GetKeyDown(rotationKey[i]))
                    {
                        rotationDir = i;
                        Rotate_Func(rotationDir);
                    }
                }
            }
            if (lerp_time > 0f && lerp_time < 1f)
            {
                Rotate_Func(rotationDir);
            }
            if (lerp_time >= 1f)
            {
                lerp_time = 0f;
                rotationDir = 0;
                add = false;
            }
        }

        void Rotate_Func(int dir)
        {
            lerp_time += Time.deltaTime / rotTime;
            switch (dir){
                //这里是左右面的旋转
                case 1:
                    for(int j = 0; j< 9; j++)
                    {
                        if (part[j].GetComponent<PartRotation>().isLeft)
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 1;
                        }
                    }
                    break;
                case 2:
                    for (int j = 0; j < 9; j++)
                    {
                        if (part[j].GetComponent<PartRotation>().isLeft)
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 2;
                        }
                    }
                    break;
                case 3:
                    for (int j = 0; j < 9; j++)
                    {
                        if (!(part[j].GetComponent<PartRotation>().isLeft))
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 1;
                        }
                    }
                    break;
                case 4:
                    for (int j = 0; j < 9; j++)
                    {
                        if (!(part[j].GetComponent<PartRotation>().isLeft))
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 2;
                        }
                    }
                    break;

                //这里是上下面的旋转
                case 5:
                    for (int j = 0; j < 9; j++)
                    {
                        if (part[j].GetComponent<PartRotation>().isUp)
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 3;
                        }
                    }
                    break;
                case 6:
                    for (int j = 0; j < 9; j++)
                    {
                        if (part[j].GetComponent<PartRotation>().isUp)
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 4;
                        }
                    }
                    break;
                case 7:
                    for (int j = 0; j < 9; j++)
                    {
                        if (!(part[j].GetComponent<PartRotation>().isUp))
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 3;
                        }
                    }
                    break;
                case 8:
                    for (int j = 0; j < 9; j++)
                    {
                        if (!(part[j].GetComponent<PartRotation>().isUp))
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 4;
                        }
                    }
                    break;

                //这里是前后面的旋转
                case 9:
                    for (int j = 0; j < 9; j++)
                    {
                        if (part[j].GetComponent<PartRotation>().isFront)
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 5;
                        }
                    }
                    break;
                case 10:
                    for (int j = 0; j < 9; j++)
                    {
                        if (part[j].GetComponent<PartRotation>().isFront)
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 6;
                        }
                    }
                    break;
                case 11:
                    for (int j = 0; j < 9; j++)
                    {
                        if (!(part[j].GetComponent<PartRotation>().isFront))
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 5;
                        }
                    }
                    break;
                case 12:
                    for (int j = 0; j < 9; j++)
                    {
                        if (!(part[j].GetComponent<PartRotation>().isFront))
                        {
                            part[j].GetComponent<PartRotation>().rotDir = 6;
                        }
                    }
                    break;
            }
        }
    }
}
