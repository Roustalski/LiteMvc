/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
	public interface IProperties
	{
		#region Methods
		
		/// <summary>
		/// Hashes the given data oject by the given key.
		/// </summary>
		void add(string key, object value);
		
		/// <summary>
		/// Creates a duplicate hash of object references for all keys.
		/// </summary>
		IProperties clone();
		
		/// <summary>
		/// Will retrieve the hashed data object by the given key.
		/// </summary>
		object get(string key);
		
		#endregion
	}
}

