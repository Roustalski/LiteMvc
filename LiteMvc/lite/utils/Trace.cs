/// <summary>
/// The Lite MVC project was created and is maintained by Russ Watson, Copyright 2010 - 2011, Some rights reserved.
/// <para/>
/// Your use of all implementations or ports of the framework, demos, and utilities is governed by the
/// Creative Commons Attribution 3.0 license: http://creativecommons.org/licenses/by/3.0/
/// </summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace LiteMvc
{
    public class Trace
    {
        private static List<Delegate> _callbacks = new List<Delegate>();

        public delegate void TraceCallback( string message );

        public static void addMessageCallback(TraceCallback fn)
        {
            if ( _callbacks == null )
            {
                writeNullError( typeof( Delegate ) );
                return;
            }
            if ( _callbacks.Contains( fn ) )
                return;

            _callbacks.Add( fn );
        }

        public static void remMessageCallback( TraceCallback fn )
        {
            if ( _callbacks == null )
            {
                writeNullError( typeof( Delegate ) );
                return;
            }
            if ( !_callbacks.Contains( fn ) )
                return;

            _callbacks.Remove( fn );
        }

        /// <summary>
        /// Sends a message in a standard format ("[timestamp][TraceLevel][message][StackTrace]") to the TraceListeners using the System.Diagnostics.Trace class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public static void writeLine(string message, TraceLevel level = TraceLevel.Info)
        {
            doWrite(message, level);
        }

        /// <summary>
        /// Sends a prebuilt message using <see cref="#writeLine"/> to inform the developer that the particular type is null.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level"></param>
        public static void writeNullError(Type type, TraceLevel level = TraceLevel.Error)
        {
            doWrite(type.FullName.ToString() + " is null.", level);
        }

        public static void writeNullError( string prependTypeMessage, Type type, TraceLevel level = TraceLevel.Error )
        {
            doWrite( prependTypeMessage + type.FullName.ToString() + " is null.", level );
        }

        public static void writeNullError( string prependTypeMessage, string appendTypeMessage, Type type, TraceLevel level = TraceLevel.Error )
        {
            doWrite( prependTypeMessage + type.FullName.ToString() + appendTypeMessage + " is null.", level );
        }

        private static void doWrite(string message, TraceLevel level = TraceLevel.Info)
        {
            string line = "[" + DateTime.Now.ToString() + "]";
            line += "[" + level.ToString() + "]" + "[" + message + "]";
            StackTrace st = new StackTrace();
            if (st.FrameCount < 2)
            {
                line += "[UNKNOWN_PACKAGE::UNKNOWN_METHOD]";
            }
            else
            {
                int verboseStacktraceLength = st.FrameCount;
                string stack = "";
                if (level != TraceLevel.Verbose)
                    verboseStacktraceLength = 3;

                for ( int frameIdx = 2; frameIdx < verboseStacktraceLength; frameIdx++ )
                {
                    stack += "\n";
                    if (frameIdx > 2)
                        stack += "  ";

                    StackFrame sf = st.GetFrame(frameIdx);
                    MethodBase mb = sf.GetMethod();
                    stack += "[" + mb.Module.Name + "::" + mb.DeclaringType.FullName + "::" + mb.Name + "]";
                    if (level == TraceLevel.Error || level == TraceLevel.Verbose)
                        stack += "[" + sf.GetFileName() + "::" + sf.GetFileLineNumber() + "]";
                }
                stack = stack.Substring(1);
                line += stack;
            }
            System.Diagnostics.Trace.WriteLine( line );

            foreach ( TraceCallback fn in _callbacks )
                fn.Invoke( line );
        }
    }
}
