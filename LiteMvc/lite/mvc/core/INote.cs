/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
	public interface INote
	{
		/// <summary>
		/// The notification interest provided by one <see cref="IClient"/> to another.
		/// </summary>
		string name { get; }
		/// <summary>
		/// The data object provided by one <see cref="IClient"/> to another.
		/// </summary>
		object data { get; }
		/// <summary>
		/// The <see cref="Type"/> describing what the data parameter is, or any additional information to be provided by one <see cref="IClient"/> to another.
		/// </summary>
		object type { get; }
	}
}

