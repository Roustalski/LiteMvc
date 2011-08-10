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
    /// <summary>
    /// All framework actors extend from this base class.
    /// </summary>
    public class Client : IClient, IObserver
    {
        #region Properties - Getters / Setters

        private IApplication _app;
        public IApplication app
        {
            get { return _app; }
            set
            {
                _app = value;
                if ( _app != null )
                    onInitialized();
            }
        }

        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<string> noteInterests
        {
            get { return null; }
        }

        #endregion

        public Client()
        {
        }

        public Client(IApplication app)
        {
            this.app = app;
        }

        ~Client()
        {
            foreach ( string interest in noteInterests )
                _app.bus.unRegisterObserver( this, interest );
            _app = null;
            _id = null;
        }

        protected void onInitialized()
        {
            if ( _app == null )
            {
                Trace.writeNullError( typeof( IApplication ) );
                return;
            }
            if ( _app.bus == null )
            {
                Trace.writeNullError( typeof( IBus ) );
                return;
            }

            foreach ( string interest in noteInterests )
                _app.bus.registerObserver( this, interest );
        }

        public IClient get( Type type )
        {
            if ( _app == null )
            {
                Trace.writeNullError( typeof( IApplication ) );
                return null;
            }
            return _app.get( type );
        }

        public IClient get( String id )
        {
            if ( _app == null )
            {
                Trace.writeNullError( typeof( IApplication ) );
                return null;
            }
            return _app.get( id );
        }

        public IClient make( Type type, params object[] parameters )
        {
            if ( _app == null )
            {
                Trace.writeNullError( typeof( IApplication ) );
                return null;
            }
            return _app.make( type, parameters );
        }

        public void raze( IClient client )
        {
            if ( _app == null )
            {
                Trace.writeNullError( typeof( IApplication ) );
                return;
            }
            _app.raze( client );
        }

        public void sendNote( string interest )
        {
            doSendNote( interest );
        }

        public void sendNote( string interest, object data )
        {
            doSendNote( interest, data );
        }

        public void sendNote( string interest, object data, object type )
        {
            doSendNote( interest, data, type );
        }

        public void onNoteReceived( INote note )
        {
        }

        private void doSendNote( string interest, object data = null, object type = null )
        {
            if ( _app == null )
            {
                Trace.writeNullError( typeof( IApplication ) );
                return;
            }
            if ( _app.bus == null )
            {
                Trace.writeNullError( typeof( IBus ) );
                return;
            }
            _app.bus.notifyObservers( interest, data, type );
        }
    }
}
