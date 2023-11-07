using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Demos.Simple.Behaviours
{
    public class InventoryBehaviour : MonoBehaviour
    {
        public List<AppleBehaviour> Apples = new ();

        public void Put(AppleBehaviour apple)
        {
            apple.PickUp();
            this.Apples.Add(apple);
        }

              
    }
}