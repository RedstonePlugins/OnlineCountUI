using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger = Rocket.Core.Logging.Logger;

namespace OnlineCountUI
{
    public class Main : RocketPlugin<CountConfig>
    {
        public string Discord = "discord.gg/Q89FmUk";
        protected override void Load()
        {

            Logger.Log("[OnlineCountUI] Plugin loaded correctly");
            Console.WriteLine("Made by Redstoneplugins - Support: " + Discord);

            U.Events.OnPlayerConnected += Conectado;
            U.Events.OnPlayerDisconnected += Desconectado;
        }

        private void Desconectado(UnturnedPlayer player)
        {
            
            EffectManager.askEffectClearByID(Configuration.Instance.EffectId, player.CSteamID);
        }

        private void Conectado(UnturnedPlayer player)
        {
            EffectManager.sendUIEffect(Configuration.Instance.EffectId, 15, true , Provider.clients.Count() + " / " + Provider.maxPlayers);
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Conectado;
            U.Events.OnPlayerDisconnected -= Desconectado;
        }
    }
}
