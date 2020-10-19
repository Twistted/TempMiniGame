using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Mechanics;
using MiniGame.Gameplay;

namespace MiniGame.UI
{
    public class RoomProgress : MonoBehaviour
    {
        public bool add;//传入增加信息
        public bool reset;//传入清零信息
        public int number;//记录个数
        public GameObject _00;
        public GameObject _01;
        public GameObject _02;

        void Start()
        {
            add = false;
            reset = false;
            number = 0;
        }

        void Update()
        {
            if (add == true)
            {
                switch (number)
                {
                    case 0:
                        _00.SetActive(false);
                        _01.SetActive(true);
                        break;
                    case 1:
                        _01.SetActive(false);
                        _02.SetActive(true);
                        break;
                    default:
                        break;
                }
                number += 1;
                add = false;
            }
            if (reset == true)
            {
                _02.SetActive(false);
                _00.SetActive(true);
                number = 0;
                reset = false;
            }
        }
    }
}
