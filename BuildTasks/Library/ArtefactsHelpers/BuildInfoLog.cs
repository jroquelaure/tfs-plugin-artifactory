using System;
using System.Activities;
using System.Runtime.InteropServices;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow.Activities;

namespace JFrogTFSPlugin.Library.ArtefactsHelpers
{
    internal class BuildInfoLog
    {
        private CodeActivityContext _context;
        internal BuildInfoLog(CodeActivityContext context)
        {
            _context = context;
        }

        public void Info(string s)
        {
            //TODO find out how to log in build process
            if (_context != null) _context.TrackBuildMessage(s, BuildMessageImportance.Normal);
        }

        public void Debug(string format)
        {
            //TODO find out how to log in build process
           if(_context != null) _context.TrackBuildMessage(String.Empty, BuildMessageImportance.Low);
        }

        public void Error(string s)
        {
            //TODO find out how to log in build process
            if (_context != null) _context.TrackBuildError(s);
        }

        internal void Error(string message, Exception we)
        {
            //TODO find out how to log in build process
            if (_context != null) _context.TrackBuildError(message + " "  + we.Message);
        }
    }
}