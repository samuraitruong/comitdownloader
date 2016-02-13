//::///////////////////////////////////////////////////////////////////////////
//:: File Name: CommandLine.cs
//::///////////////////////////////////////////////////////////////////////////
/*
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 * 
 */
//::///////////////////////////////////////////////////////////////////////////
//:: Contact: sdaily2004@hotmail.com 
//:: Created By: Stephen Daily
//:: Created On: 29 October 2010
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Pre Processor Directives
//::///////////////////////////////////////////////////////////////////////////
#define DEBUG_DATA
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System; using System.Net;
using System.IO;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides methods for parsing command line arguments for iView.NET.
    /// </summary>
    public static class CommandLine
    {
        #region Fields and properties

        private const int CMD_POS_COMMAND = 0;
        private const int CMD_POS_COMMAND_ARG = 1;
        private const string CMD_SPECIAL_COMMAND = "*";
        private const string CMD_ARG_CONVERT_FORMAT = "c";
        private const string CMD_ARG_OPEN_SCREEN_CAPTURE = "sct";

        #endregion

        #region Methods

        /// <summary>
        /// Parse command line arguments. Returns a CmdResult value if a valid argument was found and parsed.
        /// </summary>
        /// <param name="sCmdArgs">Specifies an array of command line arguments to parse.</param>
        /// <returns></returns>
        public static CmdResult ParseArguments(string[] sCmdArgs)
        {
            if ((sCmdArgs != null) && (sCmdArgs.Length > 0))
            {
                // Verify that a special argument has been provided.
                if (sCmdArgs[CMD_POS_COMMAND] == CMD_SPECIAL_COMMAND)
                {
                    switch (sCmdArgs[CMD_POS_COMMAND_ARG])
                    {
                        case CMD_ARG_CONVERT_FORMAT:
                            return ConvertFile(sCmdArgs);
                        case CMD_ARG_OPEN_SCREEN_CAPTURE:
                            return CmdResult.OpenScreenCaptureTool;
                        default:
                            return CmdResult.None;
                    }
                }
                else
                {
                    string sFilePath = sCmdArgs[0];

                    if (!string.IsNullOrEmpty(sFilePath))
                    {
                        if (FileTools.IsFileExtensionValid(Path.GetExtension(sFilePath)))
                            return CmdResult.OpenImageFile;

                        if (string.Compare(Path.GetExtension(sFilePath), ".ssf", true) == 0)
                            return CmdResult.OpenSlideShowFile;
                    }
                }
            }

            return CmdResult.None;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCmdArgs"></param>
        /// <returns></returns>
        private static CmdResult ConvertFile(string[] sCmdArgs)
        {
            return CmdResult.None;
        }

        #endregion
    }
}
