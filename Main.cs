using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace educatalan02.OnlineCountUI
{
    public class Main : RocketPlugin<CountConfig>
    {
        private static DateTime lastUpdated;
        public string Discord = "discord.gg/Q89FmUk";
        protected override void Load()
        {
            Logger.Log("[OnlineCountUI] Plugin loaded correctly");
            Console.WriteLine("Made by Redstoneplugins - Support: " + Discord, Color.yellow);




            lastUpdated = DateTime.Now;


            U.Events.OnPlayerConnected += Conectado;
            U.Events.OnPlayerDisconnected += Desconectado;
        }

        private void Desconectado(UnturnedPlayer player)
        {
            
            EffectManager.askEffectClearByID(Configuration.Instance.EffectId, player.CSteamID);
        }

        private void Conectado(UnturnedPlayer player)
        {
            EffectManager.sendUIEffect(Configuration.Instance.EffectId, 15, true , Provider.clients.Count() + " / " + Provider.maxPlayers.ToString());
        }


        private void FixedUpdate()
        {

            if ((DateTime.Now - lastUpdated).Seconds > Configuration.Instance.updateInterval)
                for (int i = 0; i < Provider.clients.Count; i++)
                {
                    EffectManager.sendUIEffect(Configuration.Instance.EffectId, 15, true, Provider.clients.Count() + " / " + Provider.maxPlayers.ToString());
                }
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Conectado;
            U.Events.OnPlayerDisconnected -= Desconectado;
        }
    }
}
