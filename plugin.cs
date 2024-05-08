using System.Reflection;
using UnityEngine;
using BepInEx;
using HarmonyLib;

namespace ZenonsModTemplate
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;

        Plugin() { new Harmony(PluginInfo.GUID).PatchAll(Assembly.GetExecutingAssembly()); instance = this; } //Fixes the mod not loading.

        /// <summary>
        /// Runs when the scene loads
        /// Should be used when importing asset bundles or adding gameobjects on startup
        /// </summary>
        public void OnGameInitialised() 
        {
            Debug.Log("Game Init.");
            new GameObject().AddComponent<Mod>().gameObject.name = PluginInfo.Name; //Creates empty gameobject, adds mod component, changes name to mod name.
        }
    }
}
