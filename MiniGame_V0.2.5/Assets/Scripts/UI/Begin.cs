using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MiniGame.UI
{
    public class Begin : MonoBehaviour
    {
        public void change()
        {
            SceneManager.LoadScene("Level");
        }
    }
}
