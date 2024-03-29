﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestA1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .InstalledApp("com.companyname.a1")                    
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}