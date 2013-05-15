// ********************************
// <copyright file="GameLauncher.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;

    class GameLauncher
    {
        static void Main()
        {
            GameEngine engine = new GameEngine();
            engine.Run();
        }
    }
}
