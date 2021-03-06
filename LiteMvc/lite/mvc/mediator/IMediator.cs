﻿/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>
/// 
namespace LiteMvc
{
    /// <summary>
    /// Translates events from a view and invokes application logic via lite scripts.
    /// </summary>
    interface IMediator : IClient
    {
        /// <summary>
        /// The view component that dispatches events
        /// </summary>
        IEventDispatcher component { get; set; }
    }
}
