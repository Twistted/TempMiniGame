using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MiniGame.UI
{
    public class Team : MonoBehaviour
    {
        public void change()
        {
            SceneManager.LoadScene("Team");
        }
    }
}
