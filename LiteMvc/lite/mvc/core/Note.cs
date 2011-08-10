/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
    class Note : INote
    {
        private string _name;
        private object _data;
        private object _type;

        public Note( string name )
        {
            _name = name;
        }

        public Note( string name, object data )
        {
            _name = name;
            _data = data;
        }

        public Note( string name, object data, object type )
        {
            _name = name;
            _data = data;
            _type = type;
        }

        ~Note()
        {
            _data = null;
            _name = null;
            _type = null;
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public object data
        {
            get { return _data; }
            set { _data = value; }
        }

        public object type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
