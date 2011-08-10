/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

namespace LiteMvc
{
	public class Service : IService
    {
        public Service(string address, string gateway)
        {
            _address = address;
            _gateway = gateway;
        }

        ~Service()
        {
            _address = null;
            _gateway = null;
        }

        #region Properties

        private string _address;
        private string _gateway;

        #endregion


        #region Getters / Setters

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string gateway
        {
            get { return _gateway; }
            set { _gateway = value; }
        }

        #endregion
    }
}
