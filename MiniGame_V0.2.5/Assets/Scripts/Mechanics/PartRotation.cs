using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;

namespace MiniGame.Mechanics
{
    public class PartRotation : MonoBehaviour
    {
        public int rotDir;//旋转的方向
        //0静止；1x轴90；2x轴-90；3y轴90；4y轴-90；5z轴90；6z轴-90

        public bool isFront;//魔方块是否在前面
        public bool isUp;//魔方块是否在上面
        public bool isLeft;//魔方块是否在左面

        public float rotTime;//转动一次花费的时间
        public AnimationCurve curve;//x轴是移动时间，y轴是移动量
        public float lerp_time;//记录旋转时间
        private bool isRot;//判断在旋转中
        public Vector3 nowRot;//现在的旋转位姿
        public Vector3 rot;//旋转角度
        public Vector3 tagRot;//目标旋转位姿
        private GameObject player;//玩家

        public int temp;

        void Start()
        {
            lerp_time = 0f;
            rotDir = 0;
            player = GameObject.Find("/Player/Player_Cube");
        }

        void Update()
        {
            if (rotDir != 0)
            {
                if (!isRot)
                {
                    player.GetComponent<PlayerController>().controlEnabled = false;//玩家不可控
                    player.GetComponent<Rigidbody>().isKinematic = true;//去除动力系统
                    switch (rotDir)
                    {
                        case 1:
                            //if (tagRot[0] > 179 && tagRot[0] < 181)
                            //    rot = new Vector3(-90, 0, 0);
                            //else
                            rot = new Vector3(90, 0, 0);

                            if (isUp && isFront)
                                isFront = false;
                            else if (isUp && !isFront)
                                isUp = false;
                            else if (!isUp && isFront)
                                isUp = true;
                            else if (!isUp && !isFront)
                                isFront = true;
                            break;
                        case 2:
                            //if (tagRot[0] > 179 && tagRot[0] < 181)
                            //    rot = new Vector3(90, 0, 0);
                            //else
                                rot = new Vector3(-90, 0, 0);

                            if (isUp && isFront)
                                isUp = false;
                            else if (isUp && !isFront)
                                isFront = true;
                            else if (!isUp && isFront)
                                isFront = false;
                            else if (!isUp && !isFront)
                                isUp = true;
                            break;
                        case 3:
                            //if (tagRot[0] > 179 && tagRot[0] < 181)
                            //    rot = new Vector3(0, -90, 0);
                            //else
                                rot = new Vector3(0, 90, 0);

                            if (isFront && isLeft)
                                isFront = false;
                            else if (isFront && !isLeft)
                                isLeft = true;
                            else if (!isFront && isLeft)
                                isLeft = false;
                            else if (!isFront && !isLeft)
                                isFront = true;
                            break;
                        case 4:
                            //if (tagRot[0] > 179 && tagRot[0] < 181)
                            //    rot = new Vector3(0, 90, 0);
                            //else
                                rot = new Vector3(0, -90, 0);

                            if (isFront && isLeft)
                                isLeft = false;
                            else if (isFront && !isLeft)
                                isFront = false;
                            else if (!isFront && isLeft)
                                isFront = true;
                            else if (!isFront && !isLeft)
                                isLeft = true;
                            break;
                        case 5:
                            //if (tagRot[0] > 179 && tagRot[0] < 181)
                            //    rot = new Vector3(0, 0, -90);
                            //else
                                rot = new Vector3(0, 0, 90);

                            if (isUp && isLeft)
                                isUp = false;
                            else if (isUp && !isLeft)
                                isLeft = true;
                            else if (!isUp && isLeft)
                                isLeft = false;
                            else if (!isUp && !isLeft)
                                isUp = true;
                            break;
                        case 6:
                            //if (tagRot[0] > 179 && tagRot[0] < 181)
                            //    rot = new Vector3(0, 0, 90);
                            //else
                                rot = new Vector3(0, 0, -90);

                            if (isUp && isLeft)
                                isLeft = false;
                            else if (isUp && !isLeft)
                                isUp = false;
                            else if (!isUp && isLeft)
                                isUp = true;
                            else if (!isUp && !isLeft)
                                isLeft = true;
                            break;
                    }
                    tagRot = nowRot + rot;
                    isRot = true;
                    print("isRot = true");
                }
                rotDir = 0;
            }

            if (isRot)
            {
                lerp_time += Time.deltaTime / rotTime;
                //this.transform.eulerAngles = Vector3.Lerp(nowRot, tagRot, curve.Evaluate(lerp_time));
                //this.transform.Rotate(rot, curve.Evaluate(lerp_time) * 3.5f, Space.World);
                //this.transform.Rotate(Time.deltaTime*45f, 0, 0, Space.World);
                this.transform.Rotate(rot, 1, Space.World);

                //this.transform.rotation = Quaternion.Euler(Vector3.right * 90);

                print("!!!!!!!!转！");
                //lerp_time = 2;
            }

            if (curve.Evaluate(lerp_time) == 1)
            {
                isRot = false;
                print("isRot = false");
                lerp_time = 0;
                nowRot = this.transform.eulerAngles;
                player.GetComponent<PlayerController>().controlEnabled = true;//玩家可控
                player.GetComponent<Rigidbody>().isKinematic = false;//回复动力系统
            }
        }
    }
}
