/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
	public interface IService
	{
		/// <summary>
		/// <see cref="lite.mvc.core.IApplication#address"/>
		/// </summary>
		string address { get; set; }
		
		/// <summary>
		/// <see cref="lite.mvc.core.IApplication#gateway"/>
		/// </summary>
		string gateway { get; set; }
		/*
		function call(service:String, method:String, callback:Function = null, properties:IProperties = null, ...parameters):*;
		function cancelRequests(method:* = "*"):void;
		function dispatchNoOutstandingRequestsEvent(inCallback:Boolean = false):void;
		function getProperties(byToken:AsyncToken):IProperties;*/
		
		/// <summary>
		/// TODO: Create a call interface that returns whatever the WWW object returns
		/// </summary>
		//function call(service:String, method:String, callback:Function = null, properties:IProperties = null, ...parameters):*;
	}
}

