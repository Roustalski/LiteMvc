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
    public class AppFactory : IAppFactory
    {
        private static Assembly _assembler;

        /// <summary>
        /// The Assembly used by the IApplication implementation to create IClient implementations and to create service types.
        /// </summary>
        public static Assembly assembler
        {
            get
            {
                if ( _assembler == null )
                    _assembler = Assembly.GetExecutingAssembly();
                return _assembler;
            }
            set { _assembler = value; }
        }

        #region Properties

        private IBus _bus;
        private IDictionary _hash;
        private IService _service;

        #endregion

        /// <summary>
        /// Creates LiteMvc applications.
        /// </summary>
        /// <param name="assembler">The assembly used when creating IClient implementations.</param>
        /// <param name="bus">If not provided, the implementation <see cref="lite.mvc.core.Bus"/> will be used.</param>
        /// <param name="hash">If not provided, the implementation <see cref="System.Collections.HashTable"/> will be used.</param>
        /// <param name="service">If not provided, the implementation <see cref="lite.mvc.core.Service"/> will be used.</param>
        public AppFactory(IService service, IBus bus = null, IDictionary hash = null)
        {
            _service = service;

            if ( bus == null )
                bus = createBus();
            _bus = bus;

            if ( hash == null )
                hash = new Hashtable();
            _hash = hash;
        }

        public AppFactory( string address, string gateway = null, IBus bus = null, IDictionary hash = null )
            :this(createService( typeof(Service), address, gateway ), bus, hash) {}

        ~AppFactory()
        {
            _assembler = null;
            _bus = null;
            _hash = null;
            _service = null;
        }

        #region Getters / Setters

        public IBus bus
        {
            get { return _bus; }
            set { _bus = value; }
        }

        public IDictionary hash
        {
            get { return _hash; }
            set { _hash = value; }
        }

        public IService service
        {
            get { return _service; }
            set { _service = value; }
        }

        #endregion

        public IApplication createApplication()
        {
            return new Application( _hash, _bus, _service, _assembler, this );
        }

        /// <summary>
        /// Creates a <see cref="lite.mvc.core.Bus"/> implementation.
        /// </summary>
        /// <param name="busCircularLimit">If a note is seen more than the provided circular limit, the bus will stop sending notes of that interest for the current call stack.</param>
        /// <returns></returns>
        public static IBus createBus( int circularLimit = 10 )
        {
            return new Bus( circularLimit );
        }

        /// <summary>
        /// Creates an <see cref="lite.mvc.model.IService"/> implementation that is intended to comminicate with a server located at the given address.
        /// </summary>
        public static IService createService( Type type, string address )
        {
            IService service = null;
            try
            {
                service = (IService)AppFactory.assembler.CreateInstance( type.FullName, false, BindingFlags.CreateInstance, null, new object[] { address, null }, null, null );
                service.address = address;
            }
            catch ( Exception e )
            {
                LiteMvc.Trace.writeLine( e.Message, System.Diagnostics.TraceLevel.Error );
            }
            return service;
        }

        public static IService createService( Type type, string address, string gateway )
        {
            IService service = createService( type, address );
            if ( service != null )
                service.gateway = gateway;

            return service;
        }
    }
}
