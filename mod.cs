using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Photon.Pun;
using ZenonsModTemplate.Utils;
using UnityEngine.InputSystem;
namespace ZenonsModTemplate
{
    //You can change the class name if you want to
    public class Mod : MonoBehaviour
    {
        public static bool modded;

        //public void OnGUI() 
        //{
        //bool disconnect = GUILayout.Button("Disconnect", Array.Empty<GUILayoutOption>());

        // if (disconnect) 
        //  {
        //    LobbyUtils.Disconnect();
        // }

        //bool joinpub = GUILayout.Button("Join Random Canyon", Array.Empty<GUILayoutOption>());
        //if (joinpub) 
        //{
        //    LobbyUtils.JoinPublicRoom("canyon");
        // }
        // }


        public static Vector3[] lastLeft = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
        public static Vector3[] lastRight = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };




        public void Update() 
        {
            if (!modded) return;
            {
            int index = -1;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    index++;

                    Vector3 they = vrrig.rightHandTransform.position;
                    Vector3 notthem = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
                    float distance = Vector3.Distance(they, notthem);

                    if (distance < 0.30)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - lastRight[index]) * 6f;
                    }
                    lastRight[index] = vrrig.rightHandTransform.position;

                    they = vrrig.leftHandTransform.position;
                    distance = Vector3.Distance(they, notthem);

                    if (distance < 0.30)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.leftHandTransform.position - lastLeft[index]) * 6f;
                    }
                    lastLeft[index] = vrrig.leftHandTransform.position;
                }
            }
        }


        }
    }
}
