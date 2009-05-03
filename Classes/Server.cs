using System;

/* 
 * Copyright 2008 - 2009, Haiku, Inc. All Rights Reserved. 
 * Distributed under the terms of the MIT License. 
 * 
 * Authors: 
 *              Fredrik Modéen, (Firstname@lastname.se)
 */ 

namespace Haiku.Classes
{
    class Server
    {
        private string fServerName;
        private string fServerFullPath;
        private string fServerPath;
        public Server(string server, string serverText)
        {            
            fServerName = serverText.Trim();
            fServerFullPath = server;

            //remove the last php part
            string[] st = server.Split('/');
            fServerPath = server.Replace(st[st.Length-1], "");
        }

        public string ServerName
        {
            get { return fServerName; }            
        }
        
        public string ServerFullPath
        {
            get { return fServerFullPath; }
        }
        
        //Path To File
        public string ServerPath
        {
            get { return fServerPath; }
        }

        public override string ToString()
        {
            return fServerName;
        }
    }
}
