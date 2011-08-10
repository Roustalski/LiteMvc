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
	public interface IObserver
	{
		/// <summary>
		/// The method that is invoked by the framework when notification is sent by an actor.
		/// </summary>
		/// <param name="note">
		/// A <see cref="INote"/> object constructed by the framework.
		/// </param>
		void onNoteReceived(INote note);
		
		/// <summary>
		/// The observer provides a list of notifications that he is interested in.
		/// </summary>
		List<string> noteInterests { get; }
	}
}

