/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System.Collections.Generic;
using System.Collections;

namespace LiteMvc
{
    /// <summary>
    /// An implementation of an Observer pattern, where the role is the <i>subject</i>, maintaining a list of
    /// dependents (Observers), and notifiying them of system notes, potentially containing a data payload.
    /// </summary>
    class Bus : IBus
    {
		private int _circularLimit;
		private IDictionary _observerHash;
		private IDictionary _noteInterestsInDelivery;
		
		public Bus(int circularLimit = 10)
		{
            _observerHash = new Hashtable();
			_noteInterestsInDelivery = new Hashtable();
            _circularLimit = circularLimit;
		}

        ~Bus()
        {
            IDictionaryEnumerator observers = _observerHash.GetEnumerator();
            while ( observers.MoveNext() )
                ( (List<IObserver>)observers.Current ).Clear();
            _observerHash.Clear();
            _observerHash = null;
            _noteInterestsInDelivery = null;
        }

        /// <summary>
        /// Returns a List of all IObserver objects for a given notification interest.
        /// </summary>
        public List<IObserver> getObservers(string interest)
        {
            if ( _observerHash == null )
            {
                Trace.writeNullError( "The observer ", typeof( IDictionary ) );
                return null;
            }
            if ( !_observerHash.Contains(interest) )
                return null;

            return (List<IObserver>)_observerHash[interest];
        }

        /// <summary>
        /// Checks to see if an observer is registered for the given interest.
        /// </summary>
        public bool hasObserver(IObserver observer, string interest)
        {
            return _observerHash != null && _observerHash.Contains( interest ) && ( (List<IObserver>)_observerHash[interest] ).Contains( observer );
        }

        public void notifyObservers( string interest )
        {
            doNotify( new Note( interest ) );
        }

        public void notifyObservers(string interest, object data)
        {
            doNotify( new Note( interest, data ) );
        }

        /// <summary>
        /// Provides all interested observers with an INote implementation.
        /// </summary>
        public void notifyObservers(string interest, object data, object type)
        {
            doNotify( new Note( interest, data, type ) );
        }

        private void doNotify( INote note )
        {
            if ( _noteInterestsInDelivery == null )
            {
                Trace.writeNullError( "The delivery ", typeof( IDictionary ) );
                return;
            }

            string interest = note.name;

            List<IObserver> list = getObservers( interest );
            if ( list == null )
            {
                Trace.writeNullError( typeof( List<IObserver> ), System.Diagnostics.TraceLevel.Warning );
                return;
            }

            if ( _noteInterestsInDelivery.Contains( interest ) )
            {
                Trace.writeLine( "Notifying observers again for interest: " + interest, System.Diagnostics.TraceLevel.Warning );
                _noteInterestsInDelivery[interest] = (int)_noteInterestsInDelivery[interest] + 1;
            }
            else
            {
                _noteInterestsInDelivery[interest] = 1;
            }

            List<IObserver> executeList = new List<IObserver>( list );
            while ( executeList.Count > 0 )
            {
                IObserver observer = executeList[0];
                observer.onNoteReceived( note );
                executeList.RemoveAt( 0 );
            }

            _noteInterestsInDelivery[interest] = (int)_noteInterestsInDelivery[interest] - 1;
            if ( (int)_noteInterestsInDelivery[interest] == 0 )
                _noteInterestsInDelivery.Remove( interest );
        }

        /// <summary>
        /// Where observers are added to the subject.
        /// </summary>
        public void registerObserver(IObserver observer, string interest)
        {
            if ( _observerHash == null )
            {
                Trace.writeNullError( "The observer ", typeof( IDictionary ) );
                return;
            }

            if ( !_observerHash.Contains( interest ) )
                _observerHash.Add( interest, new List<IObserver>() );

            if ( !hasObserver( observer, interest ) )
                ( (List<IObserver>)_observerHash[interest] ).Add( observer );
        }

        /// <summary>
        /// Where observers are removed from the subject.
        /// </summary>
        public void unRegisterObserver(IObserver observer, string interest)
        {
            if ( hasObserver( observer, interest ) )
                ( (List<IObserver>)_observerHash[interest] ).Remove( observer );
        }
    }
}
