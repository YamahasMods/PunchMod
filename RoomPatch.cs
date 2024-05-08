using Photon.Pun;
using HarmonyLib;
using UnityEngine;
using ZenonsModTemplate.Utils;
namespace ZenonsModTemplate.Patches.RoomPatches
{
    
    public class RoomPatch
    {
        [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnJoinedRoom")]
        public class RoomJoinPatch 
        {
            public static void Postfix(MonoBehaviourPunCallbacks __instance)
            {
                //Debug.Log(__instance.gameObject.name);
                Mod.modded = LobbyUtils.IsModdedLobby();
            }
        }

        [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnLeftRoom")]
        public class RoomLeftPatch
        {
            public static void Postfix(MonoBehaviourPunCallbacks __instance)
            {
                //Debug.Log(__instance.gameObject.name);
                Mod.modded = false;
            }
        }


    }


}
