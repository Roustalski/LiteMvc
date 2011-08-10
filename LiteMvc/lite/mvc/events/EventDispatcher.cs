/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
    class EventDispatcher : IEventDispatcher
    {
        public event onEvent<GenericArgs> listeners;
        public void dispatch( GenericArgs args )
        {
            if ( listeners != null )
            {
                listeners( args );
            }
        }
    }

    class GenericArgs : EventArgs
    {
        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public GenericArgs( string type )
        {
            _type = type;
        }
    }
}