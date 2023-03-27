using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class DataPlayer
    {
        public int money;
        public List<string> buyItem = new List<string>();
        public static DataPlayer instance;
        void Awake()
        {
            instance = this;
        }
        
    }
}
