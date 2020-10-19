using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Gameplay;

namespace MiniGame.Mechanics
{
    public class Setting : MonoBehaviour
    {
        public int targetFrameRate;
        void Start()
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
