using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public PlayerController controller = null;

        private void Awake()
        {
            CreateSingleton();
        }
    }
}