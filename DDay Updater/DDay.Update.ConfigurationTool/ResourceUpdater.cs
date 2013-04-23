//  Copyright (c) 2006, Gustavo Franco
//  Email:  gustavo_franco@hotmail.com
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer. 
//  Redistributions in binary form must reproduce the above copyright notice, 
//  this list of conditions and the following disclaimer in the documentation 
//  and/or other materials provided with the distribution. 

//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.

using System;
using System.Collections.Generic;
using System.Text;

namespace DDay.Update.ConfigurationTool
{
    public class ResourceUpdater
    {
        #region Kernel32 Imports

        [DllImport("kernel32.dll")]
        public unsafe static extern void CopyMemory(void* dest, void* src, int length);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr BeginUpdateResource(string pFileName, bool bDeleteExistingResources);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UpdateResource(IntPtr hUpdate, uint lpType, ref string pName, ushort wLanguage, byte[] lpData, uint cbData);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern bool UpdateResource(IntPtr hUpdate, uint lpType, IntPtr pName, ushort wLanguage, byte[] lpData, uint cbData);
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern bool UpdateResource(IntPtr hUpdate, uint lpType, byte[] pName, ushort wLanguage, byte[] lpData, uint cbData);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UpdateResource(IntPtr hUpdate, uint lpType, uint lpName, ushort wLanguage, byte[] lpData, uint cbData);
        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public unsafe static extern void CopyMemory(RGBQUAD* dest, byte* src, int cb);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int SizeofResource(IntPtr hModule, IntPtr hResource);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int FreeLibrary(IntPtr hModule);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LockResource(IntPtr hGlobalResource);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResource);
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumResourceNames(IntPtr hModule, IntPtr pType, EnumResNameProc callback, IntPtr param);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool EnumResourceTypes(IntPtr hModule, EnumResTypeProc callback, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindResource(IntPtr hModule, string resourceID, IntPtr type);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindResource(IntPtr hModule, Int32 resourceID, IntPtr type);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindResource(IntPtr hModule, IntPtr resourceID, IntPtr type);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindResource(IntPtr hModule, IntPtr resourceID, string resourceName);
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string libraryName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibraryEx(string path, IntPtr hFile, LoadLibraryFlags flags);

        #endregion

        static public void UpdateResource()
        {
            HRSRC hRes;         // handle/ptr. to res. info. in hExe     
            HANDLE hUpdateRes;  // update resource handle     
            char* lpResLock;    // pointer to resource data     
            HRSRC hResLoad;     // handle to loaded resource     
            BOOL result;
            HMODULE hSrcExe, hDestExe;
            int iLoop;

            //Load the source exe from where we need the icon     
            hSrcExe = LoadLibrary();
            if (hSrcExe == NULL) return;

            // Locate the ICON resource in the .EXE file.     
            for (iLoop = 1; ; iLoop++)
            {
                CString str;
                str.Format("#%d", iLoop);
                hRes = FindResource(hSrcExe, str, RT_ICON);
                if (hRes == NULL)
                    continue;
                else if (iLoop == 10)
                    return;
                else
                    break;
            }

            // Load the ICON into global memory.     
            hResLoad = (HRSRC)LoadResource(hSrcExe, hRes);
            if (hResLoad == NULL)
                return;

            // Lock the ICON into global memory.     
            lpResLock = (char*)LockResource(hResLoad);
            if (lpResLock == NULL)
                return;

            hDestExe = LoadLibrary(lpszFile);
            if (hDestExe == NULL)
                return;

            // Locate the ICON resource in the .EXE file.     
            for (iLoop = 1; ; iLoop++)
            {
                CString str;
                str.Format("#%d", iLoop);
                if (FindResource(hDestExe, str, RT_ICON) == NULL)
                    continue;
                else if (iLoop == 10)
                    break;
                else
                    break;
            }
            FreeLibrary(hDestExe);

            // Open the file to which you want to add the ICON resource.     
            hUpdateRes = BeginUpdateResource(lpszFile, FALSE);
            if (hUpdateRes == NULL)
                return;
            result = UpdateResource(hUpdateRes, // update resource handle         
                RT_ICON, // change dialog box resource         
                MAKEINTRESOURCE(1),
                MAKELANGID(LANG_ENGLISH, SUBLANG_ENGLISH_US),  // neutral language
                lpResLock, // ptr to resource info
                SizeofResource(hSrcExe, hRes)); // size of resource info.     

            if (result == FALSE)
                return;

            // Write changes then close it.     
            if (!EndUpdateResource(hUpdateRes, FALSE))
            {
                return;
            } 
        }

        #region Macros

        public static bool IS_INTRESOURCE(IntPtr value)
        {
            if (((uint)value) > ushort.MaxValue)
                return false;
            return true;
        }

        public static bool IS_INTRESOURCE(string value)
        {
            int iResult;
            return int.TryParse(value, out iResult);
        }

        public static int MAKEINTRESOURCE(int resource)
        {
            return 0x0000FFFF & resource;
        }

        #endregion
    }
}
