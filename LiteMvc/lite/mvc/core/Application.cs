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
    /// <summary>
    /// TODO: Create docs
    /// </summary>
	public class Application : IApplication
    {
        #region Properties

        private IDictionary _clientHash;
		private IBus _bus;
		private IService _service;
        private Assembly _assembler;
        private IAppFactory _maker;

        #endregion

        /// <summary>
        /// TODO: Create docs
        /// </summary>
        /// <param name="busCircularLimit"></param>
        /// <param name="address"></param>
        /// <param name="gateway"></param>
		public Application(IDictionary clientHash, IBus bus, IService service, Assembly assembler, IAppFactory maker)
		{
            _clientHash = clientHash;
            _bus = bus;
            _service = service;
            _assembler = assembler;
            _maker = maker;
		}

        ~Application()
        {
            _assembler = null;
            _bus = null;

            if ( _clientHash != null )
            {
                _clientHash.Clear();
                _clientHash = null;
            }

            _service = null;
        }

        #region Getters / Setters

        public string address
		{
			get
			{
                if (_service == null)
                {
                    Trace.writeNullError(typeof(IService));
                    return "";
                }
                return _service.address;
			}
			set
			{
                if (_service == null)
                {
                    Trace.writeNullError(typeof(IService));
                    return;
                }
                _service.address = value;
			}
		}
		
		public IBus bus
		{
			get
			{
				return _bus;
			}
			set
			{
				_bus = value;
			}
		}
        public string gateway
        {
            get
            {
                if ( _service == null )
                {
                    Trace.writeNullError( typeof( IService ) );
                    return "";
                }
                return _service.gateway;
            }

            set
            {
                if ( _service == null )
                {
                    Trace.writeNullError( typeof( IService ) );
                    return;
                }
                _service.gateway = value;
            }
        }

        public IAppFactory maker
        {
            get { return _maker; }
        }
		
		public IService service
		{
			get
			{
				return _service;
			}
			set
			{
				_service = value;
			}
		}

        #endregion

        public IClient get(Type type)
		{
            return get(type.FullName);
		}
		
		public IClient get(String id)
        {
            if (_clientHash == null)
            {
                Trace.writeNullError( typeof( IDictionary ) );
                return null;
            }
            if ( !_clientHash.Contains( id ) )
                return null;

            return (IClient)_clientHash[id];
		}
		
		
		public IClient make(Type type, params object[] parameters)
		{
            if ( type == null )
            {
                Trace.writeLine( "Unable to make an instance of a null type", System.Diagnostics.TraceLevel.Error );
                return null;
            }

            if ( _clientHash == null )
            {
                Trace.writeNullError( typeof( IDictionary ) );
                return null;
            }

            IClient instance = null;

            try
            {
                instance = (IClient)_assembler.CreateInstance( type.FullName, false, BindingFlags.CreateInstance, null, parameters, null, null );
            }
            catch ( Exception e )
            {
                Trace.writeLine( e.Message, System.Diagnostics.TraceLevel.Error );
            }

            if ( instance != null )
            {
                string key = instance.id;
                if ( key == null )
                    key = type.FullName;

                if ( _clientHash.Contains( key ) )
                    instance = (IClient)_clientHash[key];
                else
                    _clientHash[key] = instance;

                instance.app = this;
                //TODO:FIXME - create some sort of injection metadata for auto injections like the IService
            }

			return instance;
		}
		
		public void raze(IClient instance)
		{
            if ( instance == null )
            {
                Trace.writeNullError( typeof( IClient ) );
                return;
            }

            string key = instance.id;
            if ( !_clientHash.Contains( key ) )
                key = instance.GetType().FullName;

            if ( _clientHash.Contains( key ) )
                _clientHash.Remove( key );
		}
	}
}