using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MiniGame.UI
{
    public class Return : MonoBehaviour
    {
        public void change()
        {
            SceneManager.LoadScene("Outer");
        }
    }
}
