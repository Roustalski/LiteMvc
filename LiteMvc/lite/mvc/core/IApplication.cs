/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;
using System.Collections;

namespace LiteMvc
{
    /// <summary>
    /// TODO: Create some sort of configuration XML that automatically sets properties on the application instance?
    /// </summary>
	public interface IApplication
	{
		#region Properties
		
		/// <summary>
		/// The base url of the server that the application will communicate with.
		/// </summary>
		string address { get; set; }
		
		/// <summary>
        /// The bus that will be used by all <see cref="lite.mvc.core.IClient"/> instances when using the <see cref="#make"/> method.
		/// </summary>
        IBus bus { get; set; }

        /// <summary>
        /// The url relative to the <see cref="#address"/> of the server that the application will communicate with. Typically a PHP gateway.
        /// </summary>
        string gateway { get; set; }

        /// <summary>
        /// A reference to the factory that made this application instance. This is useful when spawning sub applications or creating additional services needed by the application.
        /// </summary>
        IAppFactory maker { get; }
		
        /// <summary>
        /// The service that will be injected to requesting <see cref="lite.mvc.core.IClient"/> instances via metadata.
        /// </summary>
		IService service { get; set; }
		
		#endregion
		
		#region Methods
		
		/// <summary>Retrieves an <c>IClient</c> interface by a class.</summary>
        /// <param name="type">A class <c>Type</c> to lookup an <c>IClient</c> interface</param>
        /// <returns><c>IClient</c></returns>
		IClient get(Type type);
		/// <summary>Retrieves an <c>IClient</c> interface by an id.</summary>
        /// <param name="id">An id to lookup an <c>IClient</c> interface</param>
        /// <returns><c>IClient</c></returns>
		IClient get(String id);
		
		/// <summary>
		/// Creates an instance of a <c>Type</c> with a list of parameters and hashes the instance by id. <seealso cref="IApplication#get"/>
		/// <para/>
		/// The instance of the class will be hashed by an id property. If an id property isn't
		/// found, it will be hashed by the class type. Only one instance of a type will be kept per id.
		/// <para/>
		/// If an instance is already created for an id, the hashed instance will be returned rather than a new instance.
		/// </summary>
		/// <param name="type">
		/// A <see cref="Type"/> that creates a concrete implementation of <see cref="IClient"/>.
		/// </param>
		/// <returns>
		/// A <see cref="IClient"/>
		/// </returns>	
		IClient make(Type type, params Object[] parameters);
		
		/// <summary>
		/// The <see cref="IClient"/> instance will be un-hashed if found and disposed of if it implements IDisposable.
		/// </summary>
		/// <param name="instance">
		/// An <see cref="IClient"/> instance created by the <seealso cref="#make"/> function.
		/// </param>
		void raze(IClient instance);
		
		#endregion
	}
}