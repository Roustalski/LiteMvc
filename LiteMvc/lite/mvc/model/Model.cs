﻿/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;

namespace LiteMvc
{
    public class Model : Client, IModel
    {
        private object _data;

        public Model( object data = null )
        {
            _data = data;
        }

        ~Model()
        {
            _data = null;
        }

        public object data
        {
            get { return _data; }
            set { _data = value; }
        }
        
    }
}
