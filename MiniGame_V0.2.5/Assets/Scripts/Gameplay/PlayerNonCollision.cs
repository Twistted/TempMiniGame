using MiniGame.Mechanics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MiniGame.Gameplay
{
    public class PlayerNonCollision : MonoBehaviour
    {
        private GameObject MagicCube;
        private GameObject player;

        void Start()
        {
            MagicCube = GameObject.Find("/Magic_Cube");
            player = GameObject.Find("/Player/Player_Cube");
        }

        void OnTriggerEnter(Collider collider)//这个函数在碰撞开始时候调用
        {
            if (collider.gameObject == player)
            {
                //AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
                Debug.Log("change state !");
                if (MagicCube.GetComponent<StateChange>().state == true)
                {
                    MagicCube.GetComponent<StateChange>().state = false;
                }
                else
                {
                    MagicCube.GetComponent<StateChange>().state = true;
                }
                this.GetComponent<Timer>().work = true;
            }
        }
    }
}


