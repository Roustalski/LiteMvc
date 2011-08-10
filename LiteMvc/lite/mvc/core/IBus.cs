/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;
using System.Collections.Generic;

namespace LiteMvc
{
	public interface IBus
	{
		/// <summary>
		/// Retreives a list of observers for a given interest.
		/// </summary>
		/// <returns>
		/// A list of <see cref="List&lt;IObserver&gt;"/> interfaces.
		/// </returns>
		List<IObserver> getObservers(string interest);
		
		/// <summary>
		/// Determines whether the given observer instance is interested in the given interest.
		/// </summary>
		bool hasObserver(IObserver observer, string interest);
		
		/// <summary>
		/// Sends an <see cref="INote"/> to all interested <see cref="IObserver"/> objects.
		/// </summary>
        void notifyObservers( string interest, object data, object type );
        void notifyObservers( string interest, object data );
        void notifyObservers( string interest );
		
		/// <summary>
		/// Registers an <see cref="IObserver"/> instance for a given interest.
		/// </summary>
		void registerObserver(IObserver observer, string interest);
		
		/// <summary>
		/// Unregisters an <see cref="IObserver"/> instance for a given interest.
		/// </summary>
		void unRegisterObserver(IObserver observer, string interest);
	}
}

