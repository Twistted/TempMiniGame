using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Mechanics;
using MiniGame.Gameplay;

namespace MiniGame.UI
{
    public class CharacterProgress : MonoBehaviour
    {
        public bool add;//传入增加信息
        public int number;//记录个数
        public GameObject _00;
        public GameObject _01;
        public GameObject _02;
        public GameObject _03;
        public GameObject _04;
        public GameObject _05;
        public GameObject _06;

        void Start()
        {
            add = false;
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
                    case 2:
                        _02.SetActive(false);
                        _03.SetActive(true);
                        break;
                    case 3:
                        _03.SetActive(false);
                        _04.SetActive(true);
                        break;
                    case 4:
                        _04.SetActive(false);
                        _05.SetActive(true);
                        break;
                    case 5:
                        _05.SetActive(false);
                        _06.SetActive(true);
                        break;
                    default:
                        break;
                }
                number += 1;
                add = false;
            }
        }
    }
}
