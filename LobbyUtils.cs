using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using ExitGames.Client.Photon;
using GorillaNetworking;
using UnityEngine;
namespace ZenonsModTemplate.Utils
{
    /// <summary>
    /// Easy room joining and checking if lobby is modded.
    /// </summary>
    public class LobbyUtils
    {
        static readonly PhotonNetworkController netController = PhotonNetworkController.Instance;
        static readonly Dictionary<string, GorillaNetworkJoinTrigger> mapJoinStuff = new Dictionary<string, GorillaNetworkJoinTrigger>();


        public static void SetupMapJoinStuff() 
        {
            mapJoinStuff.Add("forest", GameObject.Find("JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>());
            mapJoinStuff.Add("cave", GameObject.Find("JoinPublicRoom - Cave").GetComponent<GorillaNetworkJoinTrigger>());
            mapJoinStuff.Add("mountain", GameObject.Find("JoinPublicRoom - Mountain For Computer").GetComponent<GorillaNetworkJoinTrigger>());
            mapJoinStuff.Add("beach", GameObject.Find("JoinPublicRoom - Beach from Forest").GetComponent<GorillaNetworkJoinTrigger>());
            mapJoinStuff.Add("sky", GameObject.Find("JoinPublicRoom - Clouds").GetComponent<GorillaNetworkJoinTrigger>());
            mapJoinStuff.Add("canyon", GameObject.Find("JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>());
            

        }

        public static bool IsModdedLobby()
        {
            if (PhotonNetwork.InRoom)
            {
                string gameMode = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString();
                if (gameMode.Contains("modded") || gameMode.Contains("_MOD"))
                {
                    //UnityEngine.Debug.Log("Room is a modded lobby :D");
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Joins specific room, duh.
        /// </summary>
        /// <param name="code"></param>
        public static void JoinRoomWithCode(string code) => netController.AttemptToJoinSpecificRoom(code);

        /// <summary>
        /// Do I even need to explain this one?
        /// </summary



        // <param name="gameMode">infection, hunt, paintbrawl, casual</param>


        /// <summary>
        /// Joins Random Public Room, you can set the map. Default map is Forest.
        /// </summary>
        /// <param name="map">forest, beach, sky, canyon, city, cave, mountain</param>
        public static void JoinPublicRoom(string map) 
        {

            GorillaNetworkJoinTrigger joinTrigger = GameObject.Find("JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>(); //as a default, incase map is invalid.

            foreach (KeyValuePair<string, GorillaNetworkJoinTrigger> keyValuePair in mapJoinStuff) 
            {
                if (keyValuePair.Key.Contains(map.ToLower())) 
                {
                    joinTrigger = keyValuePair.Value;
                    break;
                }
            }

            netController.AttemptToJoinPublicRoom(joinTrigger);
            

        }
    }
}
