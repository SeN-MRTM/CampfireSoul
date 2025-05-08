using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [Serializable]
    public class BiomeTile
    {

        public bool isFloor;
        public Material biomMaterial;

        public BiomeTile(bool isFloor, Material biomMaterial)
        {
            this.isFloor = isFloor;
            this.biomMaterial = biomMaterial;
        }
    }
}
