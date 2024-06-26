﻿using MAUIBlazorContactApp.Services.ContactServices;
using Microsoft.Extensions.Logging;

namespace MAUIBlazorContactApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ContactDB.db3");

            builder.Services.AddSingleton<IContactRepository, ContactService>(p => ActivatorUtilities.CreateInstance<ContactService>(p, dbPath));
            return builder.Build();
        }
    }
}
