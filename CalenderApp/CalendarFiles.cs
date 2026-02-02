using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// ============================================================================
// (c) Sandy Bultena 2018
// * Released under the GNU General Public License
// ============================================================================


namespace Calendar
{

    /// <summary>
    /// CalendarFiles class is used to manage the files used in the Calendar project
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// CalenderFiles File = New CalenderFiles()
    /// 
    /// String FilePath = ".\Users\TestUser\AppData\Local\Calendar"
    /// String FileName = "calendar.txt"
    ///
    /// File.VerifyReadFromFileName(FilePath,FileName)
    /// File.VerifyWriteFromFileName(FilePath,FileName)
    /// ]]>
    /// </code>
    /// </example>
    public class CalendarFiles
    {
        private static String DefaultSavePath = @"Calendar\";
        private static String DefaultAppData = @"%USERPROFILE%\AppData\Local\";

        // ====================================================================
        // verify that the name of the file, or set the default file, and 
        // is it readable?
        // throws System.IO.FileNotFoundException if file does not exist
        // ====================================================================

        /// <summary>
        /// Verfies if the path to the file exists
        /// </summary>
        /// <param name="FilePath">Relative Path to the file</param>
        /// <param name="DefaultFileName">The Name of the file</param>
        /// <returns>Returns FilePah if Valid.</returns>
        /// <exception cref="FileNotFoundException">Throws when the filepath does not exist.</exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// String nullPath = null
        /// String fileName = "Calendar.txt"
        /// 
        /// CalenderFiles File = New CalenderFiles()
        /// 
        /// String returnPath = File.VerifyReadFromFileName(NullPath,FileName)
        /// Console.WriteLine(ReturnPath) = "%USERPROFILE%\\AppData\\Local\\" "Calendar\\" "Calendar.txt"
        /// 
        /// String fakePath =  ".\This\Drive\Does\Not\Exist"
        /// returnPath = File.VerifyReadFromFileName(FakePath,fileName)
        /// returnPath = FileNotFoundException "ReadFromFileException: FilePath (" + FakePath + ") Does not exist"
        /// 
        /// string realPath = "".\Users\TestUser\AppData\Local\Calendar""
        /// returnPath = File.VerifyReadFromFileName(realPath,fileName)
        /// 
        /// Console.WriteLine(realPath) = "".\Users\TestUser\AppData\Local\Calendar""
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public static String VerifyReadFromFileName(String? FilePath, String DefaultFileName)
        {

            // ---------------------------------------------------------------
            // if file path is not defined, use the default one in AppData
            // ---------------------------------------------------------------
            if (FilePath == null)
            {
                FilePath = Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath + DefaultFileName);
            }

            // ---------------------------------------------------------------
            // does FilePath exist?
            // ---------------------------------------------------------------
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("ReadFromFileException: FilePath (" + FilePath + ") does not exist");
            }

            // ----------------------------------------------------------------
            // valid path
            // ----------------------------------------------------------------
            return FilePath;

        }

        // ====================================================================
        // verify that the name of the file, or set the default file, and 
        // is it writable
        // ====================================================================

        /// <summary>
        /// Checks if the file is writable 
        /// </summary>
        /// <param name="FilePath">Relative Path to the file Allows Nulls</param>
        /// <param name="DefaultFileName">Name of the file</param>
        /// <returns>Returns the filepath</returns>
        /// <exception cref="Exception">Throws when the specified directory isn't valid or The file isn't capable to be edited.</exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// string nullPath = null
        /// string defaultFileName = calender.txt
        /// 
        /// 
        /// 
        /// CalenderFiles File = New CalenderFiles()
        /// 
        /// Path = File.VeriyWriteToFileName(nullPath,defaultFileName)
        /// Console.WriteLine(Path) = "%USERPROFILE%\\AppData\\Local\\"
        /// 
        /// string fakePath = ".\This\Drive\Does\Not\Exist"
        /// Path = File.VerifyWriteToFileName()
        /// Path = Throw Exception ("SaveToFileException: FilePath("%USERPROFILE%\\AppData\\Local\\")
        /// 
        /// 
        /// string realPath = "".\Users\TestUser\AppData\Local\Calendar""
        /// returnPath = File.VerifyWriteFromFileName(realPath,fileName)
        /// 
        /// Console.WriteLine(realPath) = "".\Users\TestUser\AppData\Local\Calendar""
        /// 
        /// ]]>
        /// </code>
        /// </example>
        /// <exception cref="Exception">Thrown when the directory does not exist or the file is read-only.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the provided file path is null.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have the required permission. </exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the specified path is invalid. </exception>
        /// <exception cref="IOException">Thrown when an I/O error occurs. </exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid. </exception>
        /// <exception cref="PathTooLongException">Thrown when the specified path, file name, or both exceed the system-defined maximum length. </exception>
        /// <exception cref="NotSupportedException">Thrown when the path is in an invalid format. </exception>
        /// <exception cref="System.Security.SecurityException">Thrown when the caller does not have the required permission. </exception>"
        public static String VerifyWriteToFileName(String? FilePath, String DefaultFileName)
        {
            // ---------------------------------------------------------------
            // if the directory for the path was not specified, then use standard application data
            // directory
            // ---------------------------------------------------------------
            if (FilePath == null)
            {
                // create the default appdata directory if it does not already exist
                String tmp = Environment.ExpandEnvironmentVariables(DefaultAppData);
                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                }

                // create the default Calendar directory in the appdirectory if it does not already exist
                tmp = Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath);
                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                }

                FilePath = Environment.ExpandEnvironmentVariables(DefaultAppData + DefaultSavePath + DefaultFileName);
            }

            // ---------------------------------------------------------------
            // does directory where you want to save the file exist?
            // ... this is possible if the user is specifying the file path
            // ---------------------------------------------------------------
            String? folder = Path.GetDirectoryName(FilePath);
            String delme = Path.GetFullPath(FilePath);
            if (!Directory.Exists(folder))
            {
                throw new Exception("SaveToFileException: FilePath (" + FilePath + ") does not exist");
            }

            // ---------------------------------------------------------------
            // can we write to it?
            // ---------------------------------------------------------------
            if (File.Exists(FilePath))
            {
                FileAttributes fileAttr = File.GetAttributes(FilePath);
                if ((fileAttr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    throw new Exception("SaveToFileException:  FilePath(" + FilePath + ") is read only");
                }
            }

            // ---------------------------------------------------------------
            // valid file path
            // ---------------------------------------------------------------
            return FilePath;

        }



    }
}
