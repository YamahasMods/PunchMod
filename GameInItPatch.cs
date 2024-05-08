using UnityEngine;
using HarmonyLib;
using ZenonsModTemplate.Utils;

namespace ZenonsModTemplate.Patches.OnGameInitalised
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player), "Awake")]
    public class GameInitPatch
    {
        public static void Postfix() 
        {
            Plugin.instance.OnGameInitialised();
            LobbyUtils.SetupMapJoinStuff();
            Debug.Log($"{PluginInfo.Name} has loaded. Mod made with Zenons Mod Template."); //ofc im gonna plug my name in here somewhere
        }
    }
}
