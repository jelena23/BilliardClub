﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BilliardClub.Startup))]
namespace BilliardClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
