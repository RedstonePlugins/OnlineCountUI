using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace educatalan02.OnlineCountUI
{
    public class CountConfig : IRocketPluginConfiguration
    {

        public ushort EffectId = 15000;
        public void LoadDefaults()
        {
            EffectId = 15000;
        }
    }
}
