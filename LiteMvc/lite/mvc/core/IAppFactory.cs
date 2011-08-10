/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;
using System.Collections;
using System.Reflection;

namespace LiteMvc
{
    public interface IAppFactory
    {
        #region Getters / Setters

        /// <summary>
        /// <see cref="lite.mvc.core.IBus"/>
        /// </summary>
        IBus bus { get; set; }

        /// <summary>
        /// The IApplication implementation will store the created IClients in this dictionary.
        /// </summary>
        IDictionary hash { get; set; }

        /// <summary>
        /// <see cref="lite.mvc.model.IService"/>
        /// </summary>
        IService service { get; set; }

        #endregion

        /// <summary>
        /// Creates a <see cref="lite.mvc.core.Application"/> instance based on the assembler, hash, bus, and service properties of this interface's implementation.
        /// </summary>
        IApplication createApplication();
    }
}
