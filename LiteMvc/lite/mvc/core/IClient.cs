/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
	public interface IClient
	{
		/// <summary>
		/// A reference to the <see cref="IApplication"/>.
		/// </summary>
	    IApplication app { get; set; }
		
		/// <summary>
		/// The identifier for the instance. Typically the type definition.
		/// </summary>
        string id { get; set; }

        /// <summary>
        /// <see cref="lite.mvc.core.IApplication#get"/>
        /// </summary>
        IClient get( Type type );
        /// <summary>
        /// <see cref="lite.mvc.core.IApplication#get"/>
        /// </summary>
        IClient get( String id );
		
		/// <summary>
		/// <see cref="lite.mvc.core.IApplication#make"/>
		/// </summary>
		IClient make(Type type, params object[] parameters);

        /// <summary>
        /// <see cref="lite.mvc.core.IApplication#raze"/>
        /// </summary>
        /// <param name="client"></param>
        void raze( IClient client );
		
		/// <summary>
		/// Sends an <see cref="INote"/> to all <see cref="IClient"/>s interested in the provided interest.
		/// </summary>
		void sendNote(string interest);
		/// <summary>
		/// Sends an <see cref="INote"/> to all <see cref="IClient"/>s interested in the provided interest with a piece of data.
		/// </summary>
		void sendNote(string interest, object data);
		/// <summary>
		/// Sends an <see cref="INote"/> to all <see cref="IClient"/>s interested in the provided interest with a piece of data and a type object describing the data object.
		/// </summary>
		void sendNote(string interest, object data, object type);
	}
}

